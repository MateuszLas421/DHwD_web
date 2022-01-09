using System.ComponentModel.DataAnnotations;

namespace Models.ModelsDB
{
    public class Info
    {
        [Key]
        public int Id { get; set; }
        public string DbVersion { get; set; }
        public string ApiVersion { get; set; }
    }
}
