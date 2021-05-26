using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ModelsDB
{
    public class ActivePlace
    {
        [Key]
        public int ID { get; set; }

        public int Team_Id { get; set; }

        public bool Active { get; set; }

        public int TypePlace { get; set; }

        public bool Blocked { get; set; }

        public string UnlockedPlace { get; set; }

        public bool IsEndPlace { get; set; }

        public bool Required { get; set; }

        public bool IsCompleted { get; set; }

        public string QuizStatus { get; set; }

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
