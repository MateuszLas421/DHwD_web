using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Models
{
    public class Games
    {
        [Key]   
        public int Id { get; set; }
        [Required]
        public DateTime DateTimeStart { get; set; }
        [Required]
        public DateTime DateTimeEnd { get; set; }
        [Required]
        public DateTime DateTimeCreate { get; set; }
        [Required]
        public DateTime DateTimeEdit { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Place> Place { get; set; }
    }
}
