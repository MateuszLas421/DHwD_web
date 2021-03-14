using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
{
    public class Mysterys
    {
        [Key]
        public int ID { get; set; }

        public Solutions Solutions { get; set; }

        public ICollection<Location> Locations { get; set; }

        public int SolutionsRef { get; set; }

    }
}
