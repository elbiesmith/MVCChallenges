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
    public class FizzBuzzController : Controller
    {
        /*------- FIZZBUZZ ----------*/
        public int tempValue = 0;

        public IActionResult FizzBuzz()
        {
            FizzBuzzModel model = new();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FizzBuzz(int fizzValue, int buzzValue, int startValue, int endValue)
        {
            FizzBuzzModel model = new();



            if(startValue > endValue)
            {
                tempValue = endValue;
                endValue = startValue;
                startValue = tempValue;

            }

            for (int i = startValue; i <= endValue; i++)
            {
                if (i % fizzValue == 0 && i % buzzValue == 0)
                {
                    model.Results.Add("FizzBuzz");
                }
                else if (i % fizzValue == 0)
                {
                    model.Results.Add("Fizz");
                }
                else if (i % buzzValue == 0)
                {
                    model.Results.Add("Buzz");
                }
                else
                {
                    model.Results.Add(i.ToString());
                }
            }

            return View(model);
        }

        /* -------End FIZZBUZZ ------*/
        private readonly ILogger<FizzBuzzController> _logger;

        public FizzBuzzController(ILogger<FizzBuzzController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}