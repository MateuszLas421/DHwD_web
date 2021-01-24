using DHwD_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Dtos
{
    public class ActivePlacesCreateDto
    {
        public bool Active { get; set; }
        public Place Place { get; set; }
        public ActivePlacesCreateDto()
        { }
        public ActivePlacesCreateDto(Place place)
        {
            Active = true;
            Place = place;
        }
    }
}
