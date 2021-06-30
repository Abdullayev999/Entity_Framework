using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH_and_TPT.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> Staff { get; set; }
    }
}
