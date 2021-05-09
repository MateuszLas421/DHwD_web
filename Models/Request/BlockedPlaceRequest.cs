using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Request
{
    public class BlockedPlaceRequest
    {
        public int Id_Place { get; set; }

        public int Id_Team { get; set; }

        public int Id_Game { get; set; }

        public int Id_Location { get; set; }

    }
}
