using Models.ModelsDB;
using System;

namespace DHwD_web.Dtos
{
    public class LocationReadDto
    {
        public int ID { get; set; }

        public Double Latitude { get; set; }

        public Double Longitude { get; set; }

        public Place Place { get; set; }
    }
}
