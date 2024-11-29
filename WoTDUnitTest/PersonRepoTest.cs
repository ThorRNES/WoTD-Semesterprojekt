using WorkOutToDO.Models;
using WoTD_Semesterprojekt.Repos;

namespace WoTDUnitTest
{
    [TestClass]
    public class PersonRepoTest
    {
        //private const bool useDatabase = true;
        //Database skal være her:  private static GenericDbContext _dbContext;
        private PersonRepo _repo;
        private readonly Person _badperson = new() {Id = 0, FName = "1", Gender = "no", Age = 1, AvgPulse = 20, Weight = 20, Height = 20 };
        //[ClassInitialize]
        //public static void InitOnce(TestContext context)
        //{
        //    if (useDatabase)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<MoviesDbContext>();
        //        optionsBuilder.UseSqlServer(DBSecrets.ConnectionStringSimply);
        //        _dbContext = new MoviesDbContext(optionsBuilder.Options);
        //        List<Movie> all = _dbContext.Movies.ToList();
        //        _dbContext.RemoveRange(all);

        //        _dbContext.SaveChanges();
        //    }
        //}

        [TestInitialize]
        public void Init()
        {
            //if (useDatabase)
            //{
            //    _repo = new MoviesRepositoryDB(_dbContext);
            //    _dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Movies");
            //}
            //else
            { _repo = new PersonRepo(); }

            _repo.Add(new Person() { Id = 4, FName = "Martin Skytte", Gender = "Male", Age = 59, AvgPulse = 120, Weight = 68, Height = 195 });
            _repo.Add(new Person() { Id = 5, FName = "Thomas Bruun", Gender = "Male", Age = 30, AvgPulse = 135, Weight = 58, Height = 182 });
            _repo.Add(new Person() { Id = 6, FName = "Arda Hansen", Gender = "Male", Age = 22, AvgPulse = 100, Weight = 70, Height = 168 });
            _repo.Add(new Person() { Id = 7, FName = "Hanne Hansen", Gender = "Female", Age = 72, AvgPulse = 170, Weight = 40, Height = 144 });

        }
        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Person> persons = _repo.Get();
            Assert.AreEqual(7, persons.Count());
            Assert.AreEqual(persons.First().FName, "Jens Peter");

            IEnumerable<Person> sortedPersons = _repo.Get(orderBy: "fname");
            IEnumerable<Person> sortedPersonsdesc = _repo.Get(orderBy: "fname_desc");
            Assert.AreEqual(sortedPersons.First().FName, "Arda Hansen");
            Assert.AreEqual(sortedPersonsdesc.First().FName, "Thomas Bruun");

            IEnumerable<Person> sortedPersons2 = _repo.Get(orderBy: "gender");
            IEnumerable<Person> sortedPersons2desc = _repo.Get(orderBy: "gender_desc");
            Assert.AreEqual(sortedPersons2desc.First().Gender, "Male");
            Assert.AreEqual(sortedPersons2.First().Gender, "Female");

            IEnumerable<Person> sortedPersons3 = _repo.Get(orderBy: "age");
            IEnumerable<Person> sortedPersons3desc = _repo.Get(orderBy: "age_desc");
            Assert.AreEqual(sortedPersons3desc.First().Age, 72);
            Assert.AreEqual(sortedPersons3.First().Age, 22);
           

            IEnumerable<Person> sortedPersons4 = _repo.Get(orderBy: "avgpulse");
            IEnumerable<Person> sortedPersons4desc = _repo.Get(orderBy: "avgpulse_desc");
            Assert.AreEqual(sortedPersons4.First().AvgPulse, 100);
            Assert.AreEqual(sortedPersons4desc.First().AvgPulse, 170);

            IEnumerable<Person> sortedPersons5 = _repo.Get(orderBy: "weight");
            IEnumerable<Person> sortedPersons5desc = _repo.Get(orderBy: "weight_desc");
            Assert.AreEqual(sortedPersons5.First().Weight, 40);
            Assert.AreEqual(sortedPersons5desc.First().Weight, 90);

            IEnumerable<Person> sortedPersons6 = _repo.Get(orderBy: "height");
            IEnumerable<Person> sortedPersons6desc = _repo.Get(orderBy: "height_desc");
            Assert.AreEqual(sortedPersons6.First().Height, 144);
            Assert.AreEqual(sortedPersons6desc.First().Height, 195);
                

        }
        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_repo.GetById(1));
            Assert.IsNull(_repo.GetById(9999));

        }
        [TestMethod()]
        public void AddTest()
        {
            Person p = new() { Id = 5, FName = "birgit Hansen", Gender = "Female", Age = 52, AvgPulse = 150, Weight = 50, Height = 194 };
            Assert.AreEqual(5, _repo.Add(p).Id);
            Assert.AreEqual(8, _repo.Get().Count());
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> _repo.Add(_badperson));
     

        }
        [TestMethod()]
        public void RemoveTest()
        {
            // Remover en der null.
            Assert.IsNull(_repo.Remove(100));
            // Finder Id 1 og remover objekt med id 1
            Assert.AreEqual(1, _repo.Remove(1)?.Id);
            // Finder hvor mange objekter er tilbage i repoet.
            Assert.AreEqual(6, _repo.Get().Count());
        }
        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(7, _repo.Get().Count());
            Person r = new() { Id = 5, FName = "birgit Hansen", Gender = "Female", Age = 52, AvgPulse = 150, Weight = 50, Height = 194 };
            Assert.IsNull(_repo.Update(100, r));
            Assert.AreEqual(1, _repo.Update(1, r)?.Id);
            Assert.AreEqual(7, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Update(1, _badperson));
        }


    }
}