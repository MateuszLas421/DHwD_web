using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Models.Respone
{
    public class BaseRespone : HttpResponseMessage
    {
        public bool Succes { get; set; }
    
        public string Message { get; set; }

        public int ErrorCode { get; set; }

    }
}
