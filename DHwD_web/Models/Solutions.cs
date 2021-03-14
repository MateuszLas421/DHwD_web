﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
{
    public class Solutions
    {
        [Key]
        public int ID { get; set; }

        public string MysterySolutionPozitive { get; set; }

        public string MysterySolutionNegative { get; set; }

        public ICollection<Mysterys> Mysterys { get; set; }
    }
}