using EgyptExcavation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Components
{
    public class BurialFilterViewComponent : ViewComponent
    {
        public EgyptContext context { get; set; }

        public BurialFilterViewComponent(EgyptContext ctx)
        {
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            //return View(context.Burial.ToList());
            return View();
        }
    }
}
