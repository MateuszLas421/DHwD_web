﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models.ModelsDB
{
    public class Chats
    {
        [Key]
        public int Id { get; set; }

        public bool IsSystem { get; set; }

        public string Text { get; set; }

        public DateTime DateTimeCreate { get; set; }

        public Team Team { get; set; }

        public Games Game { get; set; }
    }
}
