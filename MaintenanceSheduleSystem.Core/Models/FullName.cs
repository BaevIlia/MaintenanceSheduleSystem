using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Core.Models
{
    public class FullName
    {
        public FullName(string surname, string firstName, string lastName)
        {
            Surname = surname;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Surname { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Surname} {FirstName} {LastName}";
        }

        public static FullName ParseFullName(string fullName) 
        {
            string[] nameParts = fullName.Split(' ');
            string surname = nameParts[0];
            string firstName = nameParts[1];
            string lastName = nameParts[2];


            FullName result = new(surname, firstName, lastName);

            return result;
        }
    }
}
