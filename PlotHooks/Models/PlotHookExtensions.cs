using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PlotHooks.Models
{
	public partial class PlotHook
	{
		private static Random rng = new Random();

		public string Generate()
		{
			StringBuilder result = new StringBuilder();

			foreach (var step in Steps)
			{
				result.Append(step.Name.Trim());
				result.Append(' ');

				if (step.Selections != null && step.Selections.Any())
				{
					result.Append(step.Selections.Shuffle(rng).First().Text.Trim());
					result.Append(' ');
				}
			}

			return result.ToString();
		}

		public void Clean()
		{
			foreach (var step in Steps)
			{
				if (step.Name == null)
				{
					step.Name = "";
				}

				foreach (var nullSelection in step.Selections.Where(s => s.Text == null).ToList())
				{
					step.Selections.Remove(nullSelection);
				}
			}
		}
	}
}