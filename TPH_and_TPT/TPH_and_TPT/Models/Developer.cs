using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH_and_TPT.Models
{
    //[Table("Developers")]
    public class Developer : Person
    {
        public string Position { get; set; }
        public string Project { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\t{Position.PadRight(12,' ')}\t{Project}";
        }
    }
}
