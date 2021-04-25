using System.ComponentModel.DataAnnotations;

namespace Models.ModelsDB
{
    public class Status
    {
        [Key]
        public int ID { get; set; }

        public Team Team { get; set; }

        [Required]
        public string Game_Status { get; set; }

        public string List_Id_ActivePlace { get; set; }

        public string List_Id_Required_Pleaces_To_End { get; set; }
    }
}
