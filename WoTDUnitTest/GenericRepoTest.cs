using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutToDO.Models;
using WorkOutToDO.Repos;

namespace WoTDUnitTest
{
    [TestClass]
    public class GenericRepoTest
    {
        //private const bool useDatabase = true;
        // Database skal være her:  private static GenericDbContext _dbContext;
        private WorkOutToDO.Repos.GenericRepo<Exercise> _repo;
        private readonly Exercise badobj = new() { Name = "Push-Ups", Type = "Strength", Muscle = "Chest", Equipment = null, Difficulty = null, Instructions = null };
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
            { _repo = new GenericRepo<Exercise>(); }

            _repo.Add(new Exercise() { Name = "Rickshaw Lift", Type = "Strength", Muscle = "Back", Equipment = "Rickshaw equipment", Difficulty = "Hard", Instructions = "Center yourself and left evenly with your back straightened" });
            _repo.Add(new Exercise() { Name = "Push-Ups", Type = "Calisthenics", Muscle = "Chest", Equipment = "None", Difficulty = "Easy", Instructions = "Lay on the ground with your hands at shoulder length and push yourself up" });
            _repo.Add(new Exercise() { Name = "Sit-Ups", Type = "Calisthenics", Muscle = "Abs", Equipment = "None", Difficulty = "Easy", Instructions = "Lay down with your feet to your bottom and sit up" });

        }
        [TestMethod()]
        public void AddTest()
        {
            _repo.Add(new Exercise { Name = "Squats", Type = "Calisthentics", Muscle = "Glutes", Equipment = "None", Difficulty = "Medium", Instructions = "Squat down" });
            Exercise newExercise = _repo.Add(new Exercise { Name = "DeadLift", Type = "Strength", Muscle = "Back", Equipment = "Bar", Difficulty = "Hard", Instructions = "Squat down and carry the bar with your back straightened and lift up" });
            //Assert.IsTrue(snowWhite.Id >= 0);
            // Exercises og person har ikke ID... hvorfor
            IEnumerable<Exercise> all = _repo.Get();
            Assert.AreEqual(5, all.Count());
            Assert.ThrowsException<ArgumentNullException>(
                () => _repo.Add(new Exercise { Name = null, Type = null, Muscle = null, Equipment = null, Difficulty = null, Instructions = null }));
            Assert.ThrowsException<ArgumentException>(
                () => _repo.Add(new Exercise { Name = "", Type = "Example", Muscle = "Example", Equipment = "Example", Difficulty = "Example", Instructions = "Example"}));
            //Assert.ThrowsException<ArgumentOutOfRangeException>(
            //    () => _repo.Add(new Movie { Title = "B", Year = 1894 }));
        }

    }
}
