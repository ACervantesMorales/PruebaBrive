﻿using System.Web;
using System.Web.Mvc;

namespace Capa_de_Servicios_WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
