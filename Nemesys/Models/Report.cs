using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Nemesys.Models
{
    public class Report
    {
        
        public int Id { get; set; }
        public DateTime DateOfReport { get; set; }
        public string Location { get; set; }
        public DateTime DateOfSpotting { get; set; }
        public HazardTypes TypeOfHazard { get; set; }
        public string Description { get; set; }
        public StatusTypes Status { get; set; }
        public int ReporterId { get; set; }
        public Reporter Reporter { get; set; }
        public string ImageUrl { get; set; }
        public int UpVotes { get; set; }
        public int? InvestigationId { get; set; }
        public Investigation? Investigation { get; set; }


    }

    public enum HazardTypes
    {
        Unknown,
        UnsafeAct,
        Condition,
        Equipment,
        Structure
    }

    public enum StatusTypes 
    {
        Open,
        Closed,
        BeingInvestigated,
        NoActionRequired
    }


}