using DHwD_web.Models;
using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Dtos
{
    public class TeamMembersReadDto
    {
        public int Id { get; set; }
        public UserReadDto User { get; set; }// FK
        public TeamReadDto Team { get; set; }// FK
    }
}
