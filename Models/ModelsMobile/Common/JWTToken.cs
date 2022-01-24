using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ModelsMobile.Common
{
    public class JWTToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
