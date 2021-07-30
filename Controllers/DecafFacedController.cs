using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCChallenges.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVCChallenges.Controllers
{
    public class DecafFacedController : Controller
    {
        /* ------- DECAF FACED ------*/

        public IActionResult DecafFaced()
        {
            DecafFacedModel model = new();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DecafFaced(string startWord)
        {
            DecafFacedModel model = new();

            string clearStart = Regex.Replace(startWord.ToLower(), @"[^0-9a-zA-Z]+", "");
            string clearText = Regex.Replace(startWord.ToLower(), @"[^0-9a-zA-Z]+", "");

            //char[] charArray = clearText.ToCharArray();
            //Array.Reverse(charArray);
            List<char> characters = new();
            for (int i = clearStart.Length - 1; i >= 0; i--)
            {
                characters.Add(clearStart[i]);
            }

            model.ClearText = clearText;
            model.StartWord = startWord;

            //model.ReversedWord = new string(charArray);
            model.ReversedWord = new string(characters.ToArray());

            if (model.ReversedWord == model.ClearText)
            {
                model.IsPalindrome = true;
            }
            else
            {
                model.IsPalindrome = false;
            }

            return View(model);
        }

        /*------ End DECAF FACED -------*/

        private readonly ILogger<DecafFacedController> _logger;

        public DecafFacedController(ILogger<DecafFacedController> logger)
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