using DHwD_web.Models;
using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Dtos
{
    public class TeamMembersReadDto
    {
        public int Id { get; set; }
        public User User { get; set; }// FK
        public Team Team { get; set; }// FK
    }
}
