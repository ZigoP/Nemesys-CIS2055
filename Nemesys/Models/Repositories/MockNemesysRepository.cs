using System;
using System.Composition;
using Microsoft.EntityFrameworkCore;
using Nemesys.Models.Contexts;
using Nemesys.Models.Interfaces;
namespace Nemesys.Models.Repositories
{
    public class MockNemesysRepository : INemesysRepository
    {

        private List<Report>? _report;
        private List<Investigation>? _investigation;
        private List<Reporter>? _reporter;
        private List<Investigator>? _investigator;

        public MockNemesysRepository()
        {
            if (_report == null)
            {
                InitializeReports();
            }

            if (_investigation == null)
            {
                InitializeInvestigation();
            }

            if (_reporter == null)
            {
                InitializeReporter();
            }
            if (_investigator == null)
            {
                InitializeInvestigator();
            }
        }



        #region Report

        //Initialize from constructor
        private void InitializeReports()
        {
            _report = new List<Report>()
            {
                new Report()
                {
                    Id = 1,
                    DateOfReport= DateTime.UtcNow,
                    Location = "Campus Hub Piazza",
                    DateOfSpotting = DateTime.Today,
                    TypeOfHazard= HazardTypes.Condition,
                    Description = "Pool in the Campus Hub is Broken. Don't ask how. Its just broken",
                    Status = StatusTypes.Open,
                    ReporterId="firstReporter",
                    //Reporter= new Reporter(), //*
                    //ImageUrl=
                    UpVotes= 0,

                    InvestigationId = 1,
                    Investigation= null,

                    Name = "Pool is broken",
                },
                new Report()
                {
                    Id = 2,
                    DateOfReport= DateTime.UtcNow.AddDays(-1),
                    Location = "Campus Quads",
                    DateOfSpotting = DateTime.Today.AddDays(-1),
                    TypeOfHazard= HazardTypes.UnsafeAct,
                    Description = "One of the tree's in Quads fell down",
                    Status = StatusTypes.Open,
                    ReporterId="secondReporter",
                    //Reporter= new Reporter(), 
                    //ImageUrl=
                    UpVotes= 0,

                    InvestigationId = 2,
                    Investigation= null,
                    Name = "Fallen tree in the middle of campus",
                }
            };
        }

        public void CreateReport(Report report)
        {
            report.Id = _report.Count + 1;
            _report.Add(report);
        }

        public IEnumerable<Report> GetAllReports()
        {
            List<Report> result = new List<Report>();
            foreach (var report in _report)
            {
                //report.Category = _report.FirstOrDefault(c => c.Id == report.CategoryId); ****// I don't know why its here
                result.Add(report);
            }
            return result;
        }

        public void UpdateReport(Report report)
        {
            var existingReport = _report.SingleOrDefault(bp => bp.Id == report.Id);
            if (existingReport != null)
            {
                existingReport.Name = report.Name;
                existingReport.Description = report.Description;
                existingReport.LastUpdateDate = report.LastUpdateDate;
                existingReport.ImageUrl = report.ImageUrl;
                existingReport.TypeOfHazard = report.TypeOfHazard;
                existingReport.ReporterId = report.ReporterId;

                existingReport.Location = report.Location;
                existingReport.Status = report.Status;

                existingReport.UpVotes = report.UpVotes;
                // I'm not sure if we want it to changable InvestigationId
            }
        }

        public void deleteReport(Report report)
        {
            if (report != null)
            {
                _report.Remove(report);
            }
        }

        public Report getReportByReporterId(string reporterId)
        {
            return _report.FirstOrDefault(c => c.ReporterId == reporterId);
        }

        public void upvoteReport(Report report)
        {
            report.UpVotes++;
        }

        public IEnumerable<HazardTypes> getReportByHazardType(HazardTypes hazardType)
        {
            //return _report.FirstOrDefault(c => c.TypeOfHazard == hazardType);
            throw new NotImplementedException();
        }

        public IEnumerable<StatusTypes> getReportByStatus(StatusTypes status)
        {
            //return _report.FirstOrDefault(c => c.Status == status);
            throw new NotImplementedException();
        }

        #endregion
        #region Reporter

        //Initialize from constructor
        private void InitializeReporter()
        {
            _reporter = new List<Reporter>()
            {
                new Reporter()
                {
                    Id="firstReporter",
                    Name="Ali",
                    Surname="Bulut",
                    Email="beyalibulut@gmail.com",
                    PhoneNumber="+356 99780821",
                    Reports={/*new Report(), new Report()*/},
                    ReportersRanking=1,
                },
                new Reporter()
                {
                    Id="secondReporter",
                    Name="Muhammet",
                    Surname="Bulut",
                    Email="mralibulut@outlook.com",
                    PhoneNumber="+90 544 423 30 51",
                    Reports={/*new Report(), new Report()*/},
                    ReportersRanking=2,
                }

            };

        }

        public void CreateReporter(Reporter reporter)
        {
            //reporter.Id = generateString;
            _reporter.Add(reporter);
        }

        public IEnumerable<Reporter> GetAllReporters()
        {
            List<Reporter> result = new List<Reporter>();
            foreach (var reporter in _reporter)
            {
                result.Add(reporter);
            }
            return result;
        }

        public Report GetReportById(int reportId)
        {
            var report = _report.FirstOrDefault(p => p.Id == reportId); 

            return report;
        }

        public Reporter GetReporterById(string reporterId)
        {
            var reporter = _reporter.FirstOrDefault(p => p.Id == reporterId); 
            return reporter;
        }

        #endregion
        #region Investigation

        //Initialize from constructor
        private void InitializeInvestigation()
        {
            _investigation = new List<Investigation>()
            {
                new Investigation()
                {
                    Id = 1,
                    Description= "Pool will go under construction for 1 month after this",
                    Name= "Pool's investigated",
                    LastUpdateDate= DateTime.Now,

                },
                new Investigation()
                {
                    Id = 2,
                    Description= "Tree fell because of the recent heavy winds and its being moved",
                    Name= "Tree's being moved",
                    LastUpdateDate= DateTime.Now,
                },
            };
        }

        public void CreateInvestigation(Investigation investigation)
        {
            investigation.Id = _investigation.Count + 1;
            _investigation.Add(investigation);
        }

        public IEnumerable<Investigation> GetAllInvestigations()
        {
            List<Investigation> result = new List<Investigation>();
            foreach (var investigation in _investigation)
            {
                result.Add(investigation);
            }
            return result;
        }

        public Investigation GetInvestigationById(int investigationId)
        {
            var investigation = _investigation.FirstOrDefault(p => p.Id == investigationId); 
            return investigation;
        }

        public void UpdateInvestigation(Investigation investigation)
        {
            var existingInvestigation = _investigation.SingleOrDefault(bp => bp.Id == investigation.Id);
            if (existingInvestigation != null)
            {
                existingInvestigation.Name = investigation.Name;
                existingInvestigation.Description = investigation.Description;
                existingInvestigation.LastUpdateDate = investigation.LastUpdateDate;
                existingInvestigation.Report.ImageUrl = investigation.Report.ImageUrl;
                existingInvestigation.Report.TypeOfHazard = investigation.Report.TypeOfHazard;
                existingInvestigation.InvestigatorId = investigation.InvestigatorId;
            }
        }

        public void deleteInvestigation(Investigation investigation)
        {
            if (investigation != null)
            {
                _investigation.Remove(investigation);
            }
        }

        public IEnumerable<HazardTypes> getInvestigationByHazardType(HazardTypes hazardType)
        {
            //return _investigation.FirstOrDefault(c => c.Report.TypeOfHazard == hazardType);
            throw new NotImplementedException();
        }

        public IEnumerable<StatusTypes> getInvestigationByStatus(StatusTypes statusTypes)
        {
            //return _investigation.FirstOrDefault(c => c.Report.Status == status);
            throw new NotImplementedException();
        }

        #endregion
        #region Investigator

        private void InitializeInvestigator()
        {
            _investigator = new List<Investigator>()
            {
                new Investigator()
                {
                    Id="firstInvestigator",
                    Name="Investigator Ali",
                    Surname="Bulut",
                    Email="beyalibulut@gmail.com",
                    PhoneNumber="+356 99780821",
                    Reports={/*new Report(), new Report()*/},
                    ReportersRanking=4,

                    Investigations =  {/*new Investigation(), new Investigation()*/},
                },
                new Investigator()
                {
                    Id="secondInvestigator",
                    Name="Investigator Muhammet",
                    Surname="Investigator Bulut",
                    Email="Investigator mralibulut@outlook.com",
                    PhoneNumber="Investigator +90 544 423 30 51",
                    Reports={/*new Report(), new Report()*/},
                    ReportersRanking=4,

                    Investigations =  {/*new Investigation(), new Investigation()*/},
                }
            };
        }

        public void CreateInvestigator(Investigator investigator)
        {
            //investigator.Id = generateString;
            _investigator.Add(investigator);
        }

        public IEnumerable<Investigator> GetAllInvestigators()
        {
            List<Investigator> result = new List<Investigator>();
            foreach (var investigator in _investigator)
            {
                result.Add(investigator);
            }
            return result;
        }



        public Investigator GetInvestigatorById(string investigatorId)
        {
            var investigator = _investigator.FirstOrDefault(p => p.Id == investigatorId); 
            return investigator;
        }

        public void AssignToRole(string roleId, string userId)
        {
            throw new NotImplementedException();
        }

        public void deleteReporter(Reporter reporter)
        {
            throw new NotImplementedException();
        }

        public void deleteInvestigator(Investigator investigator)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> getReportsByReporterId(string reporterId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HazardTypes> getReportByHazardType()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatusTypes> getReportByStatus()
        {
            throw new NotImplementedException();
        }



        #endregion


















    }
}

