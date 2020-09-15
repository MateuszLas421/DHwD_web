using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Models
{
    public class Place  //TODO
    {
        [Key]
        public int Id { get; set; }
        public Games Games { get; set; }
    }
}
