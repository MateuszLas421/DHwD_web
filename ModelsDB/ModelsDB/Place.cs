using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Models.ModelsDB
{
    public class Place
    {
        [Key]
        public int Id { get; set; }
        public Games Games { get; set; }
        public ICollection<ActivePlace> ActivePlace { get; set; }
        public string Name {get; set;}
        public string Description { get; set; }
        public Location Location { get; set; }
        public int LocationRef { get; set; }
    }
}
