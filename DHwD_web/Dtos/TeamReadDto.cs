using DHwD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Dtos
{
    public class TeamReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool StatusPassword { get; set; }
        public string UserNickName { get; set; }
    }
}
