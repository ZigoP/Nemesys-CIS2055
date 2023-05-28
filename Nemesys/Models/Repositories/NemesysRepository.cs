using Nemesys.Models.Contexts;
using Nemesys.Models.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Nemesys.Models.Repositories
{
    public class NemesysRepository : INemesysRepository
    {
        private readonly AppDbContext _appDbContext;

        public NemesysRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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
            throw new NotImplementedException();
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
