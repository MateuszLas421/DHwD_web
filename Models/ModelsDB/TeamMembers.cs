using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ModelsDB
{
    public class TeamMembers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public User User { get; set; }// FK
        [Required]
        public Team Team { get; set; }// FK
        public DateTime JoinTime { get; set; }
    }
}
