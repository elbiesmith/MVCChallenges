using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCChallenges.Models;
using System.Diagnostics;

namespace MVCChallenges.Controllers
{
    public class CNoteController : Controller
    {
        /*------CNOTE------ */

        public IActionResult CNote(int startValue, int endValue)
        {
            CNoteModel model = new CNoteModel();

            for (int i = startValue; i <= endValue; i++)
            {
                model.Numbers.Add(i);
            }

            return View(model);
        }

        /* ------- End CNOTE ------ */

        private readonly ILogger<CNoteController> _logger;

        public CNoteController(ILogger<CNoteController> logger)
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