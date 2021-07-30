using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCChallenges.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCChallenges.Controllers
{
    public class SunsetRidgeController : Controller
    {
        private readonly ILogger<SunsetRidgeController> _logger;

        public SunsetRidgeController(ILogger<SunsetRidgeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /* ------ Sunset Ridge ------*/

        public IActionResult SunsetRidge()
        {
            SunsetRidgeModel model = new();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SunsetRidge(string textNumber)
        {
            SunsetRidgeModel model = new();
            if (textNumber != null)
            {
                List<string> numberStrings = textNumber.Split(",").ToList();
                List<int> numberInts = new();
                for (int i = 0; i < numberStrings.Count() - 1; i++)
                {
                    numberInts.Add(Int32.Parse(numberStrings[i]));
                }
                model.CustomData = numberInts;
            }
            else
            {
                List<int> numberInts = new();
            }

            model.DefaultData = new List<int> { 3, 2, 4, 7, 6, 9 };

            if (model.CustomData.Count == 0)
            {
                int largest = 0;
                for (int i = 0; i < model.DefaultData.Count; i++)
                {
                    if (model.DefaultData[i] > largest)
                    {
                        model.LightData.Add(model.DefaultData[i]);
                        largest = model.DefaultData[i];
                    }
                    else
                    {
                        model.DarkData.Add(model.DefaultData[i]);
                    }
                }
            }
            else
            {
                int largest = 0;
                for (int i = 0; i < model.CustomData.Count; i++)
                {
                    if (model.CustomData[i] > largest)
                    {
                        model.LightData.Add(model.CustomData[i]);
                        largest = model.CustomData[i];
                    }
                    else
                    {
                        model.DarkData.Add(model.CustomData[i]);
                    }
                }
            }

            model.PopModal = true;
            return View(model);
        }

        /*------- End Sunset Ridge -----*/
    }
}