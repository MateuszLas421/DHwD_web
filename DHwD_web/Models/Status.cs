using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
{
    public class Status
    {
        [Key]
        public int ID { get; set; }
        public Team Team { get; set; }
        //[Required]
        //bool Status;   // TODO!!!
        public ActivePlace ActivePlace { get; set; }
    }
}
