using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstСommunications.Model
{
    [Table("Accounts")]
    public class Account
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int PersonId { get; set; }
       // [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }//Navigation property,FOREIGN KEY
    }
}
