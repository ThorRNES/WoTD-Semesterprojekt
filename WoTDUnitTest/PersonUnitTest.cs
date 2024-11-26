using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutToDO.Models;

namespace WoTDUnitTest
{
    [TestClass]
    public class PersonUnitTest
    {
        private Person personTrue = new Person { FName = "Thor Russel", Gender = "Mand", Age = 25, AvgPulse = 125, Weight = 65, Height = 172 };
        private Person personNameNull = new Person { FName = null, Gender = "Mand", Age = 25, AvgPulse = 125, Weight = 65, Height = 172 };
        private Person personGenderNull = new Person { FName = "Thor Russel", Gender = null, Age = 25, AvgPulse = 125, Weight = 65, Height = 172 };
        private Person personAgeNull = new Person { FName = "Thor Russel", Gender = "Mand", Age = null, AvgPulse = 125, Weight = 65, Height = 172 };
        private Person personAgeNeg = new Person { FName = "Thor Russel", Gender = "Mand", Age = -25, AvgPulse = 125, Weight = 65, Height = 172 };
        private Person personPulseNull = new Person { FName = "Thor Russel", Gender = "Mand", Age = 25, AvgPulse = null, Weight = 65, Height = 172 };
        private Person personPulseNeg = new Person { FName = "Thor Russel", Gender = "Mand", Age = 25, AvgPulse = -125, Weight = 65, Height = 172 };
        private Person personWeightNull = new Person { FName = "Thor Russel", Gender = "Mand", Age = 25, AvgPulse = 125, Weight = null, Height = 172 };
        private Person personWeightNeg = new Person { FName = "Thor Russel", Gender = "Mand", Age = 25, AvgPulse = 125, Weight = -65, Height = 172 };
        private Person personHeightNull = new Person { FName = "Thor Russel", Gender = "Mand", Age = 25, AvgPulse = 125, Weight = 65, Height = null };
        private Person personHeightNeg = new Person { FName = "Thor Russel", Gender = "Mand", Age = 25, AvgPulse = 125, Weight = 65, Height = -172 };

        [TestMethod]
        public void ValidateFNameTest()
        {
            personTrue.ValidateFName();
            Assert.ThrowsException<ArgumentNullException>(() => personNameNull.ValidateFName());
        }

        [TestMethod]
        public void ValidateGenderTest()
        {
            personTrue.ValidateGender();
            Assert.ThrowsException<ArgumentNullException>(() => personGenderNull.ValidateGender());
        }


        [TestMethod]
        public void ValidateAgeTest()
        {
            personTrue.ValidateAge();
            Assert.ThrowsException<ArgumentNullException>(() => personAgeNull.ValidateAge());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => personAgeNeg.ValidateAge());
        }
        [TestMethod]
        public void ValidateAvgPulseTest()
        {
            personTrue.ValidateAvgPulse();
            Assert.ThrowsException<ArgumentNullException>(() => personPulseNull.ValidateAvgPulse());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => personPulseNeg.ValidateAvgPulse());
        }
        [TestMethod]
        public void ValidateWeightTest()
        {
            personTrue.ValidateWeight();
            Assert.ThrowsException<ArgumentNullException>(() => personWeightNull.ValidateWeight());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => personWeightNeg.ValidateWeight());
        }
        [TestMethod]
        public void ValidateHeightTest()
        {
            personTrue.ValidateHeight();
            Assert.ThrowsException<ArgumentNullException>(() => personHeightNull.ValidateHeight());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => personHeightNeg.ValidateHeight());
        }
        [TestMethod]
        public void ValidateTest()
        {
            personTrue.Validate();
        }
        [TestMethod]
        [DataRow(13)]
        [DataRow(14)]
        [DataRow(99)]
        [DataRow(100)]

        public void ValidateBoundaryAgeTestLegal(int age)
        {
            Person person = new Person { FName = "Thor Russel", Gender = "Mand", Age = age, AvgPulse = 125, Weight = 65, Height = 172 };

            person.ValidateAge(); 
            
        }
        [TestMethod]
        [DataRow(12)]
        [DataRow(101)]

        public void ValidateBoundaryAgeTestIllegal(int age)
        {
            Person person = new Person { FName = "Thor Russel", Gender = "Mand", Age = age, AvgPulse = 125, Weight = 65, Height = 172 };
          

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => person.ValidateAge());
        }

       
        [TestMethod]
        [DataRow(50)]
        [DataRow(51)]
        [DataRow(199)]
        [DataRow(200)]
        
        public void ValidateBoundaryPulseTestLegal(int pulse)
        {
            Person person = new Person { FName = "Thor Russel", Gender = "Mand", Age = 18, AvgPulse = pulse, Weight = 65, Height = 172 };


            person.ValidateAvgPulse();


        }


        [TestMethod]
        [DataRow(49)]
        [DataRow(201)]
        public void ValidateBoundaryPulseTestIllegal(int pulse)
        {
            Person person = new Person { FName = "Thor Russel", Gender = "Mand", Age = 18, AvgPulse = pulse, Weight = 65, Height = 172 };
            

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => person.ValidateAvgPulse());

        }

    }
}