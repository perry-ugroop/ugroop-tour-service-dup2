using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Ugroop.API.Helper.Http {
    public static class Requests {

        public static void Add(HttpRequestMessage request,string key, object value) {
            request.Properties.Add(key, value);
        }

        public static void AddSessionKey(HttpRequestMessage request, object value) {
            request.Properties.Add("UserSessionId", value);
        }


    }
}