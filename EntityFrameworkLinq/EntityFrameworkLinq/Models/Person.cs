using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLinq.Models
{
    [Table("Persons")]
    public  class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{FullName.PadRight(19,' ')} {Age}\t{Salary}";
        }
    }
}
