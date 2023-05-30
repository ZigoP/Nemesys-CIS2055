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
                    Id = b.Id,
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
                CreateReportViewModel model = new CreateReportViewModel() { 
                    TypeOfHazards = Enum.GetValues(typeof(HazardTypes)).Cast<HazardTypes>().ToList()
                };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("Error");
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult CreateReport([Bind("Location, DateOfSpotting, TypeOfHazard, Description, ImageToUpload")] CreateReportViewModel newReport)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    string fileName = "";
                    if (newReport.ImageToUpload != null)
                    {
                        //At this point you should check size, extension etc...
                        //Then persist using a new name for consistency (e.g. new Guid)
                        var extension = "." + newReport.ImageToUpload.FileName.Split('.')[newReport.ImageToUpload.FileName.Split('.').Length - 1];
                        fileName = Guid.NewGuid().ToString() + extension;
                        var path = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\nemesys\\" + fileName;
                        using (var bits = new FileStream(path, FileMode.Create))
                        {
                            newReport.ImageToUpload.CopyTo(bits);
                        }
                    }

                    Report report = new Report()
                    {
                        DateOfReport = DateTime.UtcNow,
                        Location = newReport.Location,
                        DateOfSpotting = newReport.DateOfSpotting,
                        TypeOfHazard = newReport.TypeOfHazard,
                        Description = newReport.Description,
                        Status = StatusTypes.Open,
                        UpVotes = 0,
                        ReporterId = _userManager.GetUserId(User),
                        ImageUrl = "/images/nemesys/" + fileName

                    };
                    _nemesysRepository.CreateReport(report);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(new CreateReportViewModel());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("Error");
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                var report = _nemesysRepository.GetReportById(id);
                if (report == null)
                    return NotFound();
                else
                {
                    var model = new ReportViewModel()
                    {
                        Id = report.Id,
                        DateOfReport = report.DateOfReport,
                        Location = report.Location,
                        DateOfSpotting = report.DateOfSpotting,
                        TypeOfHazard = report.TypeOfHazard,
                        Description = report.Description,
                        Status = report.Status,
                        UpVotes = report.UpVotes,
                        Reporter = report.Reporter,
                        ImageUrl = report.ImageUrl,
                        Author = new AuthorViewModel()
                        {
                            Id = report.ReporterId,
                            Name = (_userManager.FindByIdAsync(report.ReporterId).Result != null) ?
                                _userManager.FindByIdAsync(report.ReporterId).Result.UserName :
                                "Anonymous"
                        }
                    };

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("Error");
            }
        }

        /*[HttpGet]
        [Authorize]
        public IActionResult CreateInvestigation() 
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult CreateInvestigation([Bind()])
        {
            return View();
        }*/
    }
}

