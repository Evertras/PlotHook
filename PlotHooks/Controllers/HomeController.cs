using PlotHooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlotHooks.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			using (Entities entities = new Entities())
			{
				return View(entities.PlotHooks.ToList());
			}
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}
	}
}
