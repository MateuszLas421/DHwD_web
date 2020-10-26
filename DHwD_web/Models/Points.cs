using System;
using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
{
    public class Points
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserPoints { get; set; }
        [Required]
        public DateTime DataTimeEdit { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
