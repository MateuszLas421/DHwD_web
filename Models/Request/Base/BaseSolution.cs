using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Request.Base
{
    public class BaseSolution
    {
        public int Id_Place { get; set; }
        public int Id_Team { get; set; }
        public string TextSolution { get; set; }
    }
}
