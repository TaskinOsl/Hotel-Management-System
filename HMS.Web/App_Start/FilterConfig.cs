﻿using System.Web.Mvc;

namespace Web.HMS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomMenuFilter());
        }
    }
}
