using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Models
{
    public class Games
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateTimeStart { get; set; }

        public DateTime DateTimeEnd { get; set; }

        public DateTime DateTimeCreate { get; set; }

        public DateTime DateTimeEdit { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Place> Place { get; set; }

        public ICollection<Chats> Chats { get; set; }
    }
}
