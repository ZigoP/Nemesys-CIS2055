using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Models;
using Nemesys.Models.Interfaces;
using Nemesys.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Composition;
using Nemesys.Models.Repositories;

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
                    Reporter = b.Reporter,
                    ImageUrl = b.ImageUrl,
                    UpVotes = b.UpVotes,
                    Author = new AuthorViewModel() { 
                        Id = b.ReporterId,
                        Name = b.Reporter.Name,
                        Surname = b.Reporter.Surname,
                        Email = b.Reporter.Email,
                        PhoneNumber = b.Reporter.PhoneNumber
                    }
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
                            /*Name = (_userManager.FindByIdAsync(report.ReporterId).Result != null) ?
                                _userManager.FindByIdAsync(report.ReporterId).Result.UserName :
                                "Anonymous"*/
                            Name = report.Reporter.Name,
                            Surname = report.Reporter.Surname,
                            Email = report.Reporter.Email,
                            PhoneNumber = report.Reporter.PhoneNumber
                        }
                    };
                    if (report.InvestigationId != null) {
                        Investigation investigation = _nemesysRepository.GetInvestigationById(report.InvestigationId ?? default(int));
                        model.Investigation = new InvestigationViewModel()
                        {
                            Id = investigation.Id,
                            Description = investigation.Description,
                            Investigator = investigation.Investigator,                          
                        };
                        if (investigation.InvestigatorId != null) {
                            Investigator investigator = _nemesysRepository.GetInvestigatorById(investigation.InvestigatorId);
                            model.Investigation.Author = new AuthorViewModel()
                            {
                                Id = investigator.Id,
                                /*Name = (_userManager.FindByIdAsync(report.ReporterId).Result != null) ?
                                    _userManager.FindByIdAsync(report.ReporterId).Result.UserName :
                                    "Anonymous"*/
                                Name = investigator.Name,
                                Surname = investigator.Surname,
                                Email = investigator.Email,
                                PhoneNumber = investigator.PhoneNumber
                            };
                        }
                    }

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("Error");
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateInvestigation(int id) 
        {
            try
            {
                var report = _nemesysRepository.GetReportById(id);
                if (report == null)
                    return NotFound();
                else
                {
                    CreateInvestigationViewModel model = new CreateInvestigationViewModel()
                    {
                        ReportId = id,
                        Statuses = Enum.GetValues(typeof(StatusTypes)).Cast<StatusTypes>().ToList()
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

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult CreateInvestigation([Bind("Description, ReportId, Status")] CreateInvestigationViewModel newInvestigation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var report = _nemesysRepository.GetReportById(newInvestigation.ReportId);
                    if (report == null)
                        return NotFound();
                    else
                    {
                        newInvestigation.Report = report;
                        newInvestigation.Report.Status = newInvestigation.Status;
                        Investigation investigation = new Investigation()
                        {
                            Description = newInvestigation.Description,
                            ReportId = newInvestigation.ReportId,
                            // Report = newInvestigation.Report,
                            InvestigatorId = _userManager.GetUserId(User)
                        };
                        _nemesysRepository.CreateInvestigation(investigation);
                        newInvestigation.Report.InvestigationId = investigation.Id;
                        _nemesysRepository.UpdateReport(newInvestigation.Report);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    var report = _nemesysRepository.GetReportById(newInvestigation.ReportId);
                    if (report == null)
                        return NotFound();
                    else
                    {
                        CreateInvestigationViewModel model = new CreateInvestigationViewModel()
                        {
                            Report = report,
                            Statuses = Enum.GetValues(typeof(StatusTypes)).Cast<StatusTypes>().ToList()
                        };
                        return View(model);
                    }
                }
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
        public IActionResult UpVote([Bind("Id")] Report report)
        {

            var reportToUpVote = _nemesysRepository.GetReportById(report.Id);
            if (reportToUpVote != null)
            {
                _nemesysRepository.upvoteReport(reportToUpVote);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteReport([Bind("Id")] Report report)
        {
            Report reportToDelete = _nemesysRepository.GetReportById(report.Id);
            if (reportToDelete != null)
            {   
                Investigation investigation = _nemesysRepository.GetInvestigationById(reportToDelete.InvestigationId ?? default(int));   
                if(investigation != null)
                {
                    DeleteInvestigation(investigation);
                }
                _nemesysRepository.deleteReport(reportToDelete);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteInvestigation([Bind("Id")] Investigation investigation)
        {
            Investigation investigationToDelete = _nemesysRepository.GetInvestigationById(investigation.Id);

            if (investigationToDelete != null)
            {
                Report report = _nemesysRepository.GetReportById(investigationToDelete.ReportId);
                report.InvestigationId = null;
                _nemesysRepository.UpdateReport(report);
                _nemesysRepository.deleteInvestigation(investigationToDelete);
            }

            return RedirectToAction("Index");
        }
    }
}

