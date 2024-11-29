using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutToDO.Models;
using WoTD_Semesterprojekt.Models;

namespace WoTDUnitTest
{
    [TestClass]
    public class MeasurementUnitTest
    {
        private Measurement measurementTrue = new Measurement(120, "2024-11-29");
        private Measurement measurementNullPulse = new Measurement(null, "2024-11-29");
        private Measurement measurementNegativePulse = new Measurement(-1, "2024-11-29");
        private Measurement measurementNullDate = new Measurement(120, null);




        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("120 2024-11-29", measurementTrue.ToString());

        }
        [TestMethod]
        public void Equals_WithIdenticalObjects_ReturnsTrue()
        {
            // Arrange
             var measurementTrue1 = new Measurement(120, "2024-11-29");
             var measurementTrue2 = new Measurement(120, "2024-11-29");
       


            // Act
            var areEqual = measurementTrue1.Equals(measurementTrue2);

            // Assert
            Assert.IsTrue(areEqual);
        }
        [TestMethod]
        public void Equals_WithDifferentObjects_ReturnsFalse()
        {
            // Arrange
            var measurementfalse1 = new Measurement(120, "2024-11-29");
            var measurementfalse2 = new Measurement(300, "2029-12-20");
            // Act
            var areEqual = measurementfalse1.Equals(measurementfalse2);

            // Assert
            Assert.IsFalse(areEqual);
        }
        [TestMethod]
        public void Equals_WithNull_ReturnsFalse()
        {
            // Arrange
            var measurementTrue1 = new Measurement(120, "2024-11-29");


            // Act
            var areEqual = measurementTrue1.Equals(null);

            // Assert
            Assert.IsFalse(areEqual);
        }
        [TestMethod]
        public void GetHashCode_WithIdenticalObjects_ReturnsSameHashCode()
        {
            // Arrange
            var measurementTrue1 = new Measurement(120, "2024-11-29");
            var measurementTrue2 = new Measurement(120, "2024-11-29");

            // Act
            var hashCode1 = measurementTrue1.GetHashCode();
            var hashCode2 = measurementTrue2.GetHashCode();

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }
        [TestMethod]
        public void GetHashCode_WithDifferentObjects_ReturnsDifferentHashCodes()
        {
            // Arrange
            var measurementTrue1 = new Measurement(120, "2024-11-29");
            var measurementTrue2 = new Measurement(135, "2025-12-30");

            // Act
            var hashCode1 = measurementTrue1.GetHashCode();
            var hashCode2 = measurementTrue2.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashCode1, hashCode2);
        }
        [TestMethod]
        public void ValidateMeasurementPulseTest()
        {
            measurementTrue.ValidatePulse();
            Assert.ThrowsException<ArgumentNullException>(() => measurementNullPulse.ValidatePulse());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => measurementNegativePulse.ValidatePulse());

        }
        [TestMethod]
        public void ValidateMeasurementDateTest()
        {
            measurementTrue.ValidateDate();
            Assert.ThrowsException<ArgumentNullException>(() => measurementNullDate.ValidateDate());
        }

    }
}
