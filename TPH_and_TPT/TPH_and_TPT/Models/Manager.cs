using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH_and_TPT.Models
{
   // [Table("Managers")]
    public class Manager : Person
    {
        public string Department { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\t{Department}";
        }
    }
}
