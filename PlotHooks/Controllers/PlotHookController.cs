using PlotHooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PlotHooks.Controllers
{
	[Authorize]
    public class PlotHookController : Controller
    {
        public ActionResult Index()
        {
			using (var entities = new Entities())
			{
				return View(entities.PlotHooks.Where(p => p.UserName == User.Identity.Name).ToList());
			}
        }

		public ActionResult Create()
		{
			return View("PlotHookEditor", new PlotHook
					{
						Title = "My Awesome Plot Hook",
						Steps = new List<Step> {
							new Step { Name = "You find a(n)", Selections = new List<Selection>
								{
									new Selection { Text = "small box" },
									new Selection { Text = "obese hippopotamus"}
								},
							},

							new Step { Name = "filled with", Selections = new List<Selection>
								{
									new Selection { Text = "gems" },
									new Selection { Text = "old Nickelback albums"}
								}
							}
						}
					});
		}

		[HttpPost]
		public ActionResult Create(PlotHook plotHook)
		{
			using (Entities entities = new Entities())
			{
				plotHook.Clean();

				entities.PlotHooks.Add(plotHook);

				plotHook.UserName = User.Identity.Name;

				entities.SaveChanges();
			}

			return RedirectToAction("View", new { id = plotHook.Id });
		}

		public ActionResult Edit(int id)
		{
			using (Entities entities = new Entities())
			{
				var plotHook = entities.PlotHooks.Include(p => p.Steps.Select(s => s.Selections)).FirstOrDefault(p => p.Id == id);

				if (plotHook == null || plotHook.UserName != User.Identity.Name)
				{
					return RedirectToAction("Index");
				}

				return View("PlotHookEditor", plotHook);
			}
		}

		[HttpPost]
		public ActionResult Edit(int id, PlotHook plotHook)
		{
			using (Entities entities = new Entities())
			{
				var existing = entities.PlotHooks.FirstOrDefault(p => p.Id == id);

				if (existing == null || existing.UserName != User.Identity.Name)
				{
					return RedirectToAction("Index");
				}

				existing.Title = plotHook.Title;

				// just delete all old steps/selections
				foreach (var step in existing.Steps.ToList())
				{
					entities.Steps.Remove(step);
				}

				existing.Steps.Clear();

				existing.Steps = plotHook.Steps;

				existing.Clean();

				entities.SaveChanges();

				return RedirectToAction("View", new { id = id });
			}
		}

		[AllowAnonymous]
		public ActionResult View(int id)
		{
			PlotHook plotHook;

			using (Entities entities = new Entities())
			{
				plotHook = entities.PlotHooks.Include(p => p.Steps.Select(s => s.Selections)).FirstOrDefault(p => p.Id == id);

				if (plotHook == null)
				{
					return RedirectToAction("Index");
				}
			}

			return View(plotHook);
		}
    }
}
