using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
{
    public class Location
    {
        [Key]
        public int ID { get; set; }
        public Place Place { get; set; }
    }
}
