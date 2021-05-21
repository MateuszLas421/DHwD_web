using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ModelsDB
{
    public class Quiz
    {
        public int Id { get; set; }

        public int Id_Place { get; set; }

        public int Sequence { get; set; }

        public string Questions { get; set; }

        public string WrongAnswer { get; set; }

        public string Solution { get; set; }

        public string Message_1 { get; set; }

        public string Message_2 { get; set; }

        public string Message_3 { get; set; }

    }
}
