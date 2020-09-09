using System.ComponentModel.DataAnnotations;

namespace DHwD_web.Dtos
{
    public class UserCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string NickName { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
