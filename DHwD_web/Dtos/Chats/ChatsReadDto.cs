using System;

namespace DHwD_web.Dtos
{
    public class ChatsReadDto
    {
        public bool IsSystem { get; set; }

        public string Text { get; set; }

        public DateTime DateTimeCreate { get; set; }
    }
}
