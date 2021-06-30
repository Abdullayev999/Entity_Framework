using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst.Model
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int StyleId { get; set; } 
        public int FirmaId { get; set; } 
        public virtual Firma Firma { get; set; }
        public virtual Style Style { get; set; }
    }
}
