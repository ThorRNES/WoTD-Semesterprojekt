using WorkOutToDO.Models;
using WoTD_Semesterprojekt.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace WoTDUnitTest
{
    [TestClass]
    public class PersonRepoTest
    {
        private PersonRepo _repo;
        private readonly Person _badperson = new()
        {
            Id = 0,
            FName = "1",              // Invalid, too short for realistic names.
            Gender = "invalid",       // Invalid, "no" isn't a typical gender value.
            Age = 10,                 // Invalid, below minimum allowed age (13).
            AvgPulse = 20,            // Invalid, below the minimum pulse (50).
            Weight = -5,              // Invalid, below the minimum weight (0).
            Height = -10,             // Invalid, below the minimum height (0).
            Username = "ad min",      // Invalid, contains a space.
            Password = "short"        // Invalid, too short for a password.
        };

        [TestInitialize]
        public void Init()
        {
            _repo = new PersonRepo();

            _repo.Add(new Person()
            {
                Id = 4,
                FName = "Martin Skytte",
                Gender = "Male",
                Age = 59,
                AvgPulse = 120,
                Weight = 68,
                Height = 195,
                Username = "martinskytte",
                Password = "ValidPassword123!"
            });

            _repo.Add(new Person()
            {
                Id = 5,
                FName = "Thomas Bruun",
                Gender = "Male",
                Age = 30,
                AvgPulse = 135,
                Weight = 58,
                Height = 182,
                Username = "thomasbruun",
                Password = "AnotherValidPassword123!"
            });

            _repo.Add(new Person()
            {
                Id = 6,
                FName = "Arda Hansen",
                Gender = "Male",
                Age = 22,
                AvgPulse = 100,
                Weight = 70,
                Height = 168,
                Username = "ardahansen",
                Password = "SecurePass123!"
            });

            _repo.Add(new Person()
            {
                Id = 7,
                FName = "Hanne Hansen",
                Gender = "Female",
                Age = 72,
                AvgPulse = 170,
                Weight = 40,
                Height = 144,
                Username = "hannehansen",
                Password = "Password123!"
            });
        }

        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Person> persons = _repo.Get();
            Assert.AreEqual(7, persons.Count());

            IEnumerable<Person> sortedPersons = _repo.Get(orderBy: "fname");
            IEnumerable<Person> sortedPersonsDesc = _repo.Get(orderBy: "fname_desc");
            Assert.AreEqual(sortedPersons.First().FName, "Arda Hansen");
            Assert.AreEqual(sortedPersonsDesc.First().FName, "Thomas Bruun");
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_repo.GetById(4));
            Assert.IsNull(_repo.GetById(9999));
        }

        [TestMethod()]
        public void AddTest()
        {
            Person validPerson = new()
            {
                Id = 8,
                FName = "Birgit Hansen",
                Gender = "Female",
                Age = 52,
                AvgPulse = 150,
                Weight = 50,
                Height = 194,
                Username = "birgithansen",
                Password = "StrongPassword123!"
            };

            Assert.AreEqual(8, _repo.Add(validPerson).Id);
            Assert.AreEqual(8, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Add(_badperson));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Assert.IsNull(_repo.Remove(100));
            Assert.AreEqual(4, _repo.Remove(4)?.Id);
            Assert.AreEqual(6, _repo.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Person updatedPerson = new()
            {
                Id = 5,
                FName = "Birgit Hansen",
                Gender = "Female",
                Age = 52,
                AvgPulse = 150,
                Weight = 50,
                Height = 194,
                Username = "birgithansen",
                Password = "StrongPassword123!"
            };

            Assert.IsNull(_repo.Update(100, updatedPerson));
            Assert.AreEqual(5, _repo.Update(5, updatedPerson)?.Id);
            Assert.AreEqual(7, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Update(5, _badperson));
        }
    }
}
