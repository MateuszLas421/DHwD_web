using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ModelsDB
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NickName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Token { get; set; }

        [Required]
        public DateTime DateTimeCreate { get; set; }  //  User creation date

        [Required]
        public DateTime DateTimeEdit { get; set; }   // User edition date

        [Required]
        public Points Points { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<TeamMembers> TeamMembers { get; set; }
    }
}
