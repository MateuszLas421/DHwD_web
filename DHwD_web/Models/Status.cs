using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
{
    public class Status
    {
        [Key]
        public int ID { get; set; }
        public Team Team { get; set; }
        [Required]
        public bool Game_Status { get; set; }
        public ActivePlace ActivePlace { get; set; }
    }
}
