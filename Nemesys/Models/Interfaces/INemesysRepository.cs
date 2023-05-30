using System.Xml.Serialization;

namespace Nemesys.Models.Interfaces
{
    public interface INemesysRepository
    {
        IEnumerable<Reporter> GetAllReporters();
        IEnumerable<Investigator> GetAllInvestigators();
        IEnumerable<Report> GetAllReports();
        IEnumerable<Investigation> GetAllInvestigations();
        Reporter GetReporterById(string reporterId);
        Investigator GetInvestigatorById(string investigatorId);
        Report GetReportById(int reportId);
        Investigation GetInvestigationById(int investigationId);
        void CreateReporter(Reporter reporter);
        void CreateInvestigator(Investigator investigator);
        void CreateReport(Report report);
        void CreateInvestigation(Investigation investigation);
        void AssignToRole(string roleId, string userId);

        void UpdateReport(Report report);
        void UpdateInvestigation(Investigation investigation);

        void deleteReport(Report report);
        void deleteInvestigation(Investigation investigation);

        void deleteReporter(Reporter reporter);
        void deleteInvestigator(Investigator investigator);

        IEnumerable<Report> getReportsByReporterId(string reporterId);

        void upvoteReport(Report report);

        IEnumerable<HazardTypes> getReportByHazardType();
        //IEnumerable<HazardTypes> getInvestigationByHazardType();

        //IEnumerable<StatusTypes> getInvestigationByStatus();
        IEnumerable<StatusTypes> getReportByStatus();

    }
}
