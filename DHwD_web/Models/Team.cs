﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
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
        //public Team()
        //{
        //    Id_Founder = new User();
        //}
    }
}
