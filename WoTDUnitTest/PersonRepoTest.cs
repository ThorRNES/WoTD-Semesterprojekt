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

            _repo.Add(new Person() { Id = 1, FName = "Martin Skytte", Gender = "Male", Age = 59, AvgPulse = 120, Weight = 68, Height = 195 });
            _repo.Add(new Person() { Id = 2, FName = "Thomas Bruun", Gender = "Male", Age = 30, AvgPulse = 135, Weight = 58, Height = 182 });
            _repo.Add(new Person() { Id = 3, FName = "Arda Hansen", Gender = "Male", Age = 22, AvgPulse = 100, Weight = 70, Height = 168 });
            _repo.Add(new Person() { Id = 4, FName = "Hanne Hansen", Gender = "Female", Age = 72, AvgPulse = 170, Weight = 40, Height = 144 });

        }
        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Person> persons = _repo.Get();
            Assert.AreEqual(4, persons.Count());
            Assert.AreEqual(persons.First().FName, "Martin Skytte");

            IEnumerable<Person> sortedPersons = _repo.Get(orderBy: "fname");
            Assert.AreEqual(sortedPersons.First().FName, "Arda Hansen");

            IEnumerable<Person> sortedPersons2 = _repo.Get(orderBy: "gender");
            Assert.AreEqual(sortedPersons2.First().Gender, "Female");

            IEnumerable<Person> sortedPersons3 = _repo.Get(orderBy: "age");
            Assert.AreEqual(sortedPersons3.First().Age, 22);

            IEnumerable<Person> sortedPersons4 = _repo.Get(orderBy: "avgpulse");
            Assert.AreEqual(sortedPersons4.First().AvgPulse, 100);

            IEnumerable<Person> sortedPersons5 = _repo.Get(orderBy: "weight");
            Assert.AreEqual(sortedPersons5.First().Weight, 40);

            IEnumerable<Person> sortedPersons6 = _repo.Get(orderBy: "height");
            Assert.AreEqual(sortedPersons6.First().Height, 144);
                

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
            Assert.AreEqual(5, _repo.Get().Count());
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
            Assert.AreEqual(3, _repo.Get().Count());
        }
        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(4, _repo.Get().Count());
            Person r = new() { Id = 5, FName = "birgit Hansen", Gender = "Female", Age = 52, AvgPulse = 150, Weight = 50, Height = 194 };
            Assert.IsNull(_repo.Update(100, r));
            Assert.AreEqual(1, _repo.Update(1, r)?.Id);
            Assert.AreEqual(4, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Update(1, _badperson));
        }


    }
}