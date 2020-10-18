﻿using DHwD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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