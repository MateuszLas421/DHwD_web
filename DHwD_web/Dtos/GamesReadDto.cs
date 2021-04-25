using System;

namespace DHwD_web.Dtos
{
    public class GamesReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
    }
}
