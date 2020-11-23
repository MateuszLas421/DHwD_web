using System;
using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
{
    public class Points
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public int UserPoints { get; set; }
        [Required]
        public DateTime DataTimeEdit { get; set; }
        public DateTime DataTimeCreate { get; set; }
        public User User { get; set; }
    }
}
