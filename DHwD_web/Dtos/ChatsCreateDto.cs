using Models.ModelsDB;
using System;

namespace DHwD_web.Dtos
{
    public class ChatsCreateDto
    {
        public bool IsSystem { get; set; }

        public string Text { get; set; }

        public DateTime DateTimeCreate { get; set; }

        public Team Team { get; set; }

        public Games Game { get; set; }
    }
}
