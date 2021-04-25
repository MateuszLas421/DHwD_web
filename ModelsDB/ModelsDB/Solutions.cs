using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ModelsDB
{
    public class Solutions
    {
        [Key]
        public int ID { get; set; }

        public string Text { get; set; }

        public string MysterySolutionPozitive { get; set; }

        public string MysterySolutionNegative { get; set; }

        public Mysterys Mystery { get; set; }
    }
}
