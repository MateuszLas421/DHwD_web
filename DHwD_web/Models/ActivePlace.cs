using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
{
    public class ActivePlace
    {
        [Key]
        public int ID { get; set; }
        ///Place Place;
        public bool Active { get; set; }
        public ICollection<Status> Status { get; set; }
        public ICollection<Place> Places { get; set; }
    }
}
