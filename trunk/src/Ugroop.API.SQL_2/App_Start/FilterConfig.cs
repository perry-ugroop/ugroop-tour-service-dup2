﻿using System.Web;
using System.Web.Mvc;

namespace Ugroop.API.SQL {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
