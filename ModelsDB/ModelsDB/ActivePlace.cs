﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ModelsDB
{
    public class ActivePlace
    {
        [Key]
        public int ID { get; set; }

        public int Team_Id { get; set; }

        public bool Active { get; set; }

        public string Type { get; set; }

        public Place Place { get; set; }

        public ActivePlace() { }
        public ActivePlace(int Team_Id, Place place) 
        {
            this.Place = new Place();
            this.Team_Id = Team_Id;
            this.Place = place;
        }

    }
}