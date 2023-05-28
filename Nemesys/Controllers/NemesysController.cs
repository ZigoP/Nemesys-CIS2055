using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Models;
using Nemesys.Models.Interfaces;
using Nemesys.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Nemesys.Controllers
{
    public class NemesysController : Controller
    {
        private readonly INemesysRepository _nemesysRepository;

        //Using constructor dependency injection for the controller (i.e. when the controller is instnatiated, it will receive an instance of IBloggyRepository according to the config in Program.cs
        public NemesysController(INemesysRepository nemesysRepository)
        {
            _nemesysRepository = nemesysRepository;
        }

        public IActionResult Index()
        {
            var reports = _nemesysRepository.GetAllReports();
            var model = new ReportListViewModel()
            {
                TotalEntries = _nemesysRepository.GetAllReports().Count(),
                Reports = _nemesysRepository
                .GetAllReports()
                .OrderByDescending(b => b.DateOfReport)
                .Select(b => new ReportViewModel
                {
                    DateOfReport = b.DateOfReport,
                    Location = b.Location,
                    DateOfSpotting = b.DateOfSpotting,
                    TypeOfHazard = b.TypeOfHazard, 
                    Description = b.Description, 
                    Status = b.Status,
                    //TODO: UNCOMMENT AFTER CREATING REPORTER AND INVESTIGATION
                    Reporter = b.Reporter,
                    ImageUrl = b.ImageUrl,
                    UpVotes = b.UpVotes
                    //Investigation = b.Investigation                
                })
            };
            return View(model);  
        }


    }
}

