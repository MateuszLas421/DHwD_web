﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ModelsDB
{
    public class Mysterys
    {
        [Key]
        public int ID { get; set; }

        public string Text { get; set; }

        public Solutions Solutions { get; set; }

        public Location Location { get; set; }

        public int SolutionsRef { get; set; }

    }
}
