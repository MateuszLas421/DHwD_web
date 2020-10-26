using DHwD_web.Models;
using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Dtos
{
    public class TeamMembersReadDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public User User { get; set; }// FK
        //[Required]
        //public Team Team { get; set; }// FK
    }
}
