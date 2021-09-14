using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATBiotechTest.Services.Other
{
    public static class Utilities
    {
        public static string GetIpValue(HttpRequest httpRequest)
        {
            string ipAdd = httpRequest.Headers["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ipAdd))
            {
                return httpRequest.Headers["REMOTE_ADDR"];
            }
            return ipAdd;
        }
    }
}
