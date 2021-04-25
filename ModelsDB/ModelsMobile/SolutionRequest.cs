using System;

namespace Models.ModelsMobile
{
    public class SolutionRequest
    {
        public int IdMystery { get; private set; }

        public string TextSolution { get; private set; }

        public int gameid { get; private set; }

        public DateTime DataTimeRequest { get; set; }

    }
}
