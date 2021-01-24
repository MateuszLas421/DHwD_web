using DHwD_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Dtos
{
    public class StatusCreateDto  
    {
        public int ID { get; set; }
        public Team Team { get; set; }
        public ActivePlace ActivePlace { get; set; }
        public StatusCreateDto()
        { }
        public StatusCreateDto(Team team, ActivePlace activePlace)
        {
            Team = team;
            ActivePlace = activePlace;
        }
    }
}
