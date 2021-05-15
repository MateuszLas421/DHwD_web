using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ModelsDB.Templates
{
    public class MechanicTypeTemp
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }

    }
}
