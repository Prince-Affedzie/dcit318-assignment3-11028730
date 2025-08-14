using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare_System
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Patient(int id, string name, int age, string gender)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
        }

        public override string ToString() => $"{Name} (ID: {Id}), Age: {Age}, Gender: {Gender}";
    }
}
