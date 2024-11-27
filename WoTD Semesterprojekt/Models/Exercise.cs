using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace WorkOutToDO.Models
{
    public class Exercise
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Muscle { get; set; }
        public string Equipment { get; set; }
        public string Difficulty { get; set; }
        public string Instructions { get; set; }


        public Exercise()
        {
        }

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException("Name cannot be null");
            }
        }
        public void ValidateType()
        {
            if (Type == null)
            {
                throw new ArgumentNullException("Type cannot be null");
            }
        }
        public void ValidateMuscle()
        {
            if (Muscle == null)
            {
                throw new ArgumentNullException("Muscle cannot be null");
            }
        }
        public void ValidateEquipment()
        {
            if (Equipment == null)
            {
                throw new ArgumentNullException("Equipment cannot be null");
            }
        }
        public void ValidateDifficulty()
        {
            if (Difficulty == null)
            {
                throw new ArgumentNullException("Diffuclty cannot be null");
            }
        }
        public void ValidateInstructions()
        {
            if (Instructions == null)
            {
                throw new ArgumentNullException("Instructions cannot be null");
            }
        }
        public void Validate()
        {
            ValidateName();
            ValidateType();
            ValidateMuscle();
            ValidateEquipment();
            ValidateDifficulty();
            ValidateInstructions();
        }
        public override bool Equals(object? obj)
        {
            return obj is Exercise øvelse &&
                   Name == øvelse.Name &&
                   Type == øvelse.Type &&
                   Muscle == øvelse.Muscle &&
                   Equipment == øvelse.Equipment &&
                   Difficulty == øvelse.Difficulty &&
                   Instructions == øvelse.Instructions;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Type, Muscle, Equipment, Difficulty, Instructions);
        }
        public override string ToString()
        {
            return $"{Name} {Type} {Muscle} {Equipment} {Difficulty} {Instructions}";
        }
    }


}
