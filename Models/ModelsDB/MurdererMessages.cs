using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ModelsDB
{
    public class MurdererMessages
    {
        [Key]
        public long Id { get; set; }

        public int Id_Place { get; set; }

        public string Text { get; set; }

        public int NumerMessage { get; set; }

        public int TypeMessage { get; set; }

    }
}
