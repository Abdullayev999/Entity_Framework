using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstСommunications.Model
{
    [Table("Automobiles")]
    public class Automobile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int BrandId { get; set; } 
        //[ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
    }
}
