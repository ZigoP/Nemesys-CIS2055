using System.Xml.Serialization;

namespace Nemesys.Models.Interfaces
{
    public interface INemesysRepository
    {
        IEnumerable<Reporter> GetAllReporters();
        IEnumerable<Investigator> GetAllInvestigators();
        IEnumerable<Report> GetAllReports();
        IEnumerable<Investigation> GetAllInvestigations();
        Reporter GetReporterById(int reporterId);
        Investigator GetInvestigatorById(int investigatorId);
        Report GetReportById(int reportId);
        Investigation GetInvestigationById(int investigationId);
        void CreateReporter(Reporter reporter);
        void CreateInvestigator(Investigator investigator);
        void CreateReport(Report report);
        void CreateInvestigation(Investigation investigation);
        void AssignToRole(string roleId, string userId);

        //void UpdateBlogPost(BlogPost updatedBlogPost);

    }
}
