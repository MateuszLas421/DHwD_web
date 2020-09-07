using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DHwD.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string NickName { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public DateTime DateTimeCreate { get; set; }  //  User creation date
        [Required]
        public DateTime DateTimeEdit { get; set; }   // User edition date
    }
}
