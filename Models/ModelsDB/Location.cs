using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ModelsDB
{
    public class Location
    {
        [Key]
        public int ID { get; set; }

        public Place Place { get; set; }

        public Double Latitude { get; set; }

        public Double Longitude { get; set; }

        public Mysterys Mysterys { get; set; }
        
        public int MysteryRef { get; set; }

    }
}
