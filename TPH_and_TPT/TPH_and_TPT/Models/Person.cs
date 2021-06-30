using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH_and_TPT.Models
{
    //[Table("Persons")]
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public Department Departament { get; set; }
        public int DepartamentId { get; set; }

        public override string ToString()
        {
            return $"{FullName.PadRight(19, ' ')} {Age} {Salary}";
        }
    }
}
