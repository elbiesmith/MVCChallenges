using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCChallenges.Helpers;
using MVCChallenges.Models;
using System.Diagnostics;

namespace MVCChallenges.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILogger<LoanController> _logger;

        public LoanController(ILogger<LoanController> logger)
        {
            _logger = logger;
        }

        public IActionResult App()
        {
            Loan loan = new();
            loan.Payment = 0.0m;
            loan.TotalInterest = 0.0m;
            loan.TotalCost = 0.0m;
            loan.Rate = 3.5m;
            loan.Amount = 15000m;
            loan.Term = 60;

            return View(loan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult App(Loan loan)
        {
            var loanHelper = new LoanHelper();

            Loan newLoan = loanHelper.GetPayments(loan);

            return View(newLoan);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}