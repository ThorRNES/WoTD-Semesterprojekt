using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoTD_Semesterprojekt.Models;

namespace WorkOutToDO.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public int? AvgPulse { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public List<Measurement> Measurements { get; set; } = new();

        public Person(int id, string fName, string gender, int? age, int? avgPulse, int? weight, int? height)
        {
            Id = id;
            FName = fName;
            Gender = gender;
            Age = age;
            AvgPulse = avgPulse;
            Weight = weight;
            Height = height;
        }

        public Person()
        {
        }
        public void ValidateMeasurements()
        {
            if (Measurements == null) throw new ArgumentNullException("Measurements cannot be null");
            foreach (var measurement in Measurements)
            {
                if (measurement.Pulse < 0) throw new ArgumentOutOfRangeException("Pulse cannot be less than zero");
                if (DateTime.TryParse(measurement.Date, out _) == false)
                    throw new FormatException("Invalid date format in measurements.");
            }
        }
        public void ValidateFName()
        {
            if (FName == null) throw new ArgumentNullException("Name cannot be null");
        }
        public void ValidateGender()
        {
            if (Gender == null) throw new ArgumentNullException("gender cannot be null");
        }
        public void ValidateAge()
        {
            if (Age == null) throw new ArgumentNullException("Age cannot be null");
            if (Age > 100) throw new ArgumentOutOfRangeException("Age cannot be more than 100");
            if (Age < 13) throw new ArgumentOutOfRangeException("Age cannot be less than 13"); 
        }
        public void ValidateAvgPulse()
        {
            if (AvgPulse == null) throw new ArgumentNullException("Pulse cannot be null");
            if (AvgPulse < 50) throw new ArgumentOutOfRangeException("Pulse cannot be less than 50");
            if (AvgPulse > 200) throw new ArgumentOutOfRangeException("Pulse cannot be more than 200");
        }
        public void ValidateWeight()
        {
            if (Weight == null) throw new ArgumentNullException("Weight cannot be null");
            if (Weight < 0) throw new ArgumentOutOfRangeException("Weight cannot be less than zero");
        }
        public void ValidateHeight()
        {
            if (Height == null) throw new ArgumentNullException("Height cannot be null");
            if (Height < 0) throw new ArgumentOutOfRangeException("Height cannot be less than zero");
        }
        public void Validate()
        {
            ValidateFName();
            ValidateGender();
            ValidateAge();
            ValidateAvgPulse();
            ValidateWeight();
            ValidateHeight();
            ValidateMeasurements();
        }
        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   FName == person.FName &&
                   Gender == person.Gender &&
                   Age == person.Age &&
                   AvgPulse == person.AvgPulse &&
                   Weight == person.Weight &&
                   Height == person.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FName, Gender, Age, AvgPulse, Weight, Height);
        }

        public override string ToString()
        {
            return $"{Id} {FName} {Gender} {Age} {AvgPulse} {Weight} {Height}";
        }
    }
}
