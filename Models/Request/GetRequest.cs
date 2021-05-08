using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Request
{
    public class GetRequest
    {
        public string strURL { get; set; }

        public GetRequest(string str)
        {
            strURL = str;
        }
    }
}
