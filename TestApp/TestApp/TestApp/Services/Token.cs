using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Services
{
    public class Token
    {
        public string access_token { get; set; }
        public string expire_token { get; set; }
        public string type_token { get; set; }
        public string refresh_token { get; set; }
    }
}
