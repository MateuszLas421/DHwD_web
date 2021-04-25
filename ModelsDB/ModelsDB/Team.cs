using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ModelsDB
{
    public class Team
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public User Id_Founder { get; set; }// FK

        [Required]
        public DateTime DateTimeCreate { get; set; }  //  User creation date

        [Required]
        public DateTime DateTimeEdit { get; set; }   // User edition date

        [Required]
        public bool StatusPassword { get; set; }  //Password Exist

        [MaxLength(500)]
        public string Password { get; set; }

        public bool OnlyOnePlayer { get; set; }

        public ICollection<TeamMembers> TeamMembers { get; set; }

        public Games Games { get; set; }

        public Status Status { get; set; }

        public int StatusRef { get; set; }

        public ICollection<Chats> Chats { get; set; }
    }
}
