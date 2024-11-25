﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOutToDO.Models
{
    public class Person
    {
        public string FName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public int? AvgPulse { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }

        public Person()
        {
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
            if (Age < 0) throw new ArgumentOutOfRangeException("Age cannot be less than zero");
        }
        public void ValidateAvgPulse()
        {
            if (AvgPulse == null) throw new ArgumentNullException("Pulse cannot be null");
            if (AvgPulse < 0) throw new ArgumentOutOfRangeException("Pulse cannot be less than zero");
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
            return $"{{{nameof(FName)}={FName}, {nameof(Gender)}={Gender}, {nameof(Age)}={Age.ToString()}, {nameof(AvgPulse)}={AvgPulse}, {nameof(Weight)}={Weight.ToString()}, {nameof(Height)}={Height.ToString()}}}";
        }
    }
}
