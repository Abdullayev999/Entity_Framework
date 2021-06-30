using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstGamesSecond.Models
{
    [Table("Games")]
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [DefaultValue("GETDATE()")]
        public DateTime ReleaseDate { get; set; }
        public string IsMultiplayer { get; set; }

        public int StyleId { get; set; }
        [Required]
        [ForeignKey("StyleId")]
        public Style Style { get; set; }
        public int FirmaId { get; set; }
        [Required]
        [ForeignKey("FirmaId")] 
        public Firma Firma { get; set; }
    }
}
