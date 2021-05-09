using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Request
{
    public class GetUpdateChatRequest
    {
        public int Id_Game { get; set; }

        public int Id_Team { get; set; }

        public DateTime dateTime { get; set; }

    }
}
