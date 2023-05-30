using Nemesys.Models.Contexts;
using Nemesys.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Nemesys.Models.Repositories
{
    public class NemesysRepository : INemesysRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<NemesysRepository> _logger;


        public NemesysRepository(AppDbContext appDbContext, ILogger<NemesysRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public void AssignToRole(string roleId, string userId)
        {
            try
            {
                _appDbContext.IdentityUserRoles.Add(new IdentityUserRole<string>() { RoleId = roleId, UserId = userId });
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            
        }

        public void CreateInvestigation(Investigation investigation)
        {
            throw new NotImplementedException();
        }

        public void CreateInvestigator(Investigator investigator)
        {
            throw new NotImplementedException();
        }

        public void CreateReport(Report report)
        {
            throw new NotImplementedException();
        }

        public void CreateReporter(Reporter reporter)
        {
            try
            {
                _appDbContext.Reporters.Add(reporter);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<Investigation> GetAllInvestigations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Investigator> GetAllInvestigators()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reporter> GetAllReporters()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> GetAllReports()
        {
            return _appDbContext.Reports.Include(b => b.Reporter).Include(b => b.Investigation).OrderBy(b => b.DateOfReport);
        }

        public Investigation GetInvestigationById(int investigationId)
        {
            throw new NotImplementedException();
        }

        public Investigator GetInvestigatorById(int investigatorId)
        {
            throw new NotImplementedException();
        }

        public Report GetReportById(int reportId)
        {
            throw new NotImplementedException();
        }

        public Reporter GetReporterById(int reporterId)
        {
            throw new NotImplementedException();
        }
    }
}
