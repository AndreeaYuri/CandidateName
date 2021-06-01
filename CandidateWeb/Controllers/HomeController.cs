using CandidateWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CandidateNames.Candidate;

namespace CandidateWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var candidates = new Candidates();
            var developers = candidates.GetDeveloperJobApplicants().ToList();
            var testers = candidates.GetTesterJobApplicants().ToList();
            var allApplicantsCombined = candidates.CombineAllApplicants(developers, testers);
            var allCleanedApplicantsList = candidates.CleaningApplicantsList(allApplicantsCombined);
            var lettersFrequency = candidates.LettersFrequency(allCleanedApplicantsList);
            return View(new CandidateViewModel()
            {
                Developers = developers,
                Testers = testers,
                AllCandidates = allApplicantsCombined,
                AllCleanedCandidates = allCleanedApplicantsList,
                FrequencyLetters = lettersFrequency
            });
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
