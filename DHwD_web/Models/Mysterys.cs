using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
{
    public class Mysterys
    {
        [Key]
        public int ID { get; set; }
        public Solutions Solutions { get; set; }
        public int SolutionsRef { get; set; }
    }
}
