using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Token { get; set; }
        public DateTime DateTimeCreate { get; set; }  //  User creation date
        public DateTime DateTimeEdit { get; set; }   // User edition date
    }
}
