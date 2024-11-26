using WorkOutToDO.Models;

namespace WoTDUnitTest
{
    [TestClass]
    public class ExerciseUnitTest
    {
        private Exercise exerciseTrue = new Exercise { Name = "Incline Hammercurls", Type = "Strength", Muscle = "Strength", Equipment = "Dumpbell", Difficulty = "Beginner", Instructions = "Seat yourself..." };
        private Exercise exerciseNameNull = new Exercise { Name = null, Type = "Strength", Muscle = "Strength", Equipment = "Dumpbell", Difficulty = "Beginner", Instructions = "Seat yourself..." };
        private Exercise exerciseTypeNull = new Exercise { Name = "Incline Hammercurls", Type = null, Muscle = "Strength", Equipment = "Dumpbell", Difficulty = "Beginner", Instructions = "Seat yourself..." };
        private Exercise exerciseMuscleNull = new Exercise { Name = "Incline Hammercurls", Type = "Strength", Muscle = null, Equipment = "Dumpbell", Difficulty = "Beginner", Instructions = "Seat yourself..." };
        private Exercise exerciseEquipNull = new Exercise { Name = "Incline Hammercurls", Type = "Strength", Muscle = "Strength", Equipment = null, Difficulty = "Beginner", Instructions = "Seat yourself..." };
        private Exercise exerciseDiffiNull = new Exercise { Name = "Incline Hammercurls", Type = "Strength", Muscle = "Strength", Equipment = "Dumpbell", Difficulty = null, Instructions = "Seat yourself..." };
        private Exercise exerciseInstruNull = new Exercise { Name = "Incline Hammercurls", Type = "Strength", Muscle = "Strength", Equipment = "Dumpbell", Difficulty = "Beginner", Instructions = null };




        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Incline Hammercurls Strength Strength Dumpbell Beginner Seat yourself...", exerciseTrue.ToString());
        }

        [TestMethod]

        public void ValidateValidate()
        {

        }
        public void ValidateNameTest()
        {
            exerciseTrue.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => exerciseNameNull.ValidateName());

        }

        [TestMethod]
        public void ValidateTypeTest()
        {
            exerciseTrue.ValidateType();
            Assert.ThrowsException<ArgumentNullException>(() => exerciseTypeNull.ValidateType());
        }
        [TestMethod]
        public void ValidateMuscleTest()
        {
            exerciseTrue.ValidateMuscle();
            Assert.ThrowsException<ArgumentNullException>(() => exerciseMuscleNull.ValidateMuscle());
        }
        [TestMethod]
        public void ValidateEquipmentTest()
        {
            exerciseTrue.ValidateEquipment();
            Assert.ThrowsException<ArgumentNullException>(() => exerciseEquipNull.ValidateEquipment());
        }
        [TestMethod]
        public void ValidateDifficultyTest()
        {
            exerciseTrue.ValidateDifficulty();
            Assert.ThrowsException<ArgumentNullException>(() => exerciseDiffiNull.ValidateDifficulty());
        }
        [TestMethod]
        public void ValidateInstructionsTest()
        {
            exerciseTrue.ValidateInstructions();
            Assert.ThrowsException<ArgumentNullException>(() => exerciseInstruNull.ValidateInstructions());
        }
        [TestMethod]
        public void ValidateTest()
        {
            exerciseTrue.Validate();
        }
    }
}