using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Models;
using Nemesys.Models.Interfaces;
using Nemesys.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Nemesys.Controllers
{
    public class NemesysController : Controller
    {
        private readonly INemesysRepository _nemesysRepository;
        private readonly ILogger<NemesysController> _logger;
        private readonly UserManager<IdentityUser> _userManager;


        //Using constructor dependency injection for the controller (i.e. when the controller is instnatiated, it will receive an instance of IBloggyRepository according to the config in Program.cs
        public NemesysController(INemesysRepository nemesysRepository, ILogger<NemesysController> logger, UserManager<IdentityUser> userManager)
        {
            _nemesysRepository = nemesysRepository;
            _logger = logger;
            _userManager = userManager;
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

        [HttpGet]
        public IActionResult Register() {
            return View();   
        }

        [HttpPost]
        public IActionResult Register([Bind("Name, Surname, Email, PhoneNumber, Password")] CreateReporterViewModel newReporter) {
            Reporter reporter = new Reporter()
            {
                Name = newReporter.Name,
                Surname = newReporter.Surname,
                UserName = newReporter.Email,
                NormalizedUserName = newReporter.Email.ToUpper(),
                Email = newReporter.Email,
                NormalizedEmail = newReporter.Email.ToUpper(),
                PhoneNumber = newReporter.PhoneNumber,
                ReportersRanking = 5,
                LockoutEnabled = false,
                EmailConfirmed = true,
            };
            PasswordHasher<Reporter> passwordHasher = new PasswordHasher<Reporter>();
            reporter.PasswordHash = passwordHasher.HashPassword(reporter, newReporter.Password);
            _nemesysRepository.CreateReporter(reporter);
            _nemesysRepository.AssignToRole("reporterRoleId", reporter.Id);

            return View("SuccessfulRegistration");
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateReport()
        {
            try
            {
                var model = new CreateReportViewModel()
                {
                    DateOfReport = DateTime.UtcNow
                };

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("Error");
            }
        }


    }
}

