using DHwD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Models
{
    public class Team
    {
        [Key] //maybe add Id Games class
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public User Id_Founder { get; set; }// FK
        [Required]
        public DateTime DateTimeCreate { get; set; }  //  User creation date
        [Required]
        public DateTime DateTimeEdit { get; set; }   // User edition date
        [Required]
        public bool StatusPassword { get; set; }  //Password Exist
        [MaxLength(500)]
        public string Password { get; set; }
        public ICollection<TeamMembers> TeamMembers { get; set; }
        public Games Games { get; set; }
    }
}
