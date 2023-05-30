using Nemesys.Models.Contexts;
using Nemesys.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Composition;

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
            try
            {
                _appDbContext.Investigations.Add(investigation);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public void CreateInvestigator(Investigator investigator)
        {
            try
            {
                _appDbContext.Investigators.Add(investigator);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public void CreateReport(Report report)
        {
            try
            {
                _appDbContext.Reports.Add(report);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
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

        public void deleteInvestigation(Investigation investigation)
        {
            try
            {
                _appDbContext.Investigations.Remove(investigation);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public void deleteReport(Report report)
        {
            try
            {
                _appDbContext.Reports.Remove(report);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


        public void deleteReporter(Reporter reporter)
        {
            try
            {
                _appDbContext.Reporters.Remove(reporter);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public void deleteInvestigator(Investigator investigator)
        {
            try
            {
                _appDbContext.Investigators.Remove(investigator);
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
            try
            {
                return _appDbContext.Investigations.Include(a => a.Investigator).Include(b => b.Report).OrderBy(b => b.Report.DateOfReport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<Investigator> GetAllInvestigators()
        {
            try
            {
                //return _appDbContext.Investigators.Include(b => b.Investigations).OrderBy(b => b.Name);
                return _appDbContext.Investigators.Include(b => b.Investigations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<Reporter> GetAllReporters()
        {
            try
            {
                //return _appDbContext.Reporters.Include(b => b.Reports).OrderBy(b => b.Name);
                return _appDbContext.Reporters.Include(b => b.Reports);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<Report> GetAllReports()
        {
            return _appDbContext.Reports.Include(b => b.Reporter).Include(b => b.Investigation).OrderBy(b => b.DateOfReport);
        }

        public Investigation GetInvestigationById(int investigationId)
        {
            try
            {
                return _appDbContext.Investigations.FirstOrDefault(b => b.Id == investigationId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public Investigator GetInvestigatorById(string investigatorId)
        {
            try
            {
                return _appDbContext.Investigators.FirstOrDefault(c => c.Id == investigatorId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<HazardTypes> getReportByHazardType()
        {
            throw new NotImplementedException();
        }

        public Report GetReportById(int reportId)
        {
            try
            {
                return _appDbContext.Reports.Include(c => c.Reporter).FirstOrDefault(c => c.Id == reportId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<Report> getReportsByReporterId(string reporterId)
        {
            try
            {
                return _appDbContext.Reports.Include(b => b.Reporter).Where(c => c.Reporter.Id == reporterId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<StatusTypes> getReportByStatus()
        {
            throw new NotImplementedException();
        }

        public Reporter GetReporterById(string reporterId)
        {
            try
            {
                return _appDbContext.Reporters.FirstOrDefault(c => c.Id == reporterId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public void UpdateInvestigation(Investigation investigation)
        {
            try
            {
                var existingInvestigation = _appDbContext.Investigations.SingleOrDefault(i => i.Id == investigation.Id);
                if (existingInvestigation != null)
                {
                    //existingInvestigation.Name = investigation.Name;
                    existingInvestigation.Description = investigation.Description;
                    //existingInvestigation.LastUpdateDate = investigation.LastUpdateDate;
                    existingInvestigation.Report.ImageUrl = investigation.Report.ImageUrl;
                    existingInvestigation.Report.TypeOfHazard = investigation.Report.TypeOfHazard;
                    existingInvestigation.InvestigatorId = investigation.InvestigatorId;

                    //We should add update details if we change them

                    _appDbContext.Entry(existingInvestigation).State = EntityState.Modified;
                    _appDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public void UpdateReport(Report report)
        {
            try
            {
                var existingReport = _appDbContext.Reports.SingleOrDefault(bp => bp.Id == report.Id);
                if (existingReport != null)
                {
                    //existingReport.Name = report.Name;
                    existingReport.Description = report.Description;
                    //existingReport.LastUpdateDate = report.LastUpdateDate;
                    existingReport.ImageUrl = report.ImageUrl;
                    existingReport.TypeOfHazard = report.TypeOfHazard;
                    existingReport.ReporterId = report.ReporterId;

                    existingReport.Location = report.Location;
                    existingReport.Status = report.Status;

                    existingReport.UpVotes = report.UpVotes;
                    // I'm not sure if we want it to changable InvestigationId

                    //We should add update details if we change them

                    _appDbContext.Entry(existingReport).State = EntityState.Modified;
                    _appDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public void upvoteReport(Report report)
        {
            try
            {
                Report foundReport = GetReportById(report.Id);
                if (foundReport != null)
                {
                    foundReport.UpVotes++;
                }

                _appDbContext.Entry(foundReport).State = EntityState.Modified;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
