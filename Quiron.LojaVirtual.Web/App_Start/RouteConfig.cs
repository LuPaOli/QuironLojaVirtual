﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //1
            routes.MapRoute(null,
                "",
                new {controller = "Vitrine",
                    action = "ListaProdutos",
                    categoria = (string)null,
                    pagina = 1});

            //2
            routes.MapRoute(null,
                "Pagina{pagina}",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    categoria = (string)null},
                    new{pagina = @"\d+"});

            //3
            routes.MapRoute(null,
                "{categoria}",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    pagina = 1
                });

            //4
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
