using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
{
    public class ActivePlace
    {
        [Key]
        public int ID { get; set; }
        public bool Active { get; set; }
        public Place Place { get; set; }
        public ICollection<Status> Status { get; set; }
        public int Team_Id { get; set; }
    }
}
