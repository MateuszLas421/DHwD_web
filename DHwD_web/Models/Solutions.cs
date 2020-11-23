using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
{
    public class Solutions
    {
        [Key]
        public int ID { get; set; }
        public Mysterys Mysterys { get; set; }
    }
}
