using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Nemesys.Models.Contexts
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //This will pass any options in the constructor to the base class DbContext
        }

        public DbSet<Investigation> Investigations { get; set; }
        public DbSet<Investigator> Investigators { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Reporter> Reporters { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //IMPORTANT: Required to setup the schema for the identity framework
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<Report>()
                .HasOne(e => e.Reporter)
                .WithMany(f => f.Reports)
                .HasForeignKey(e => e.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reporter>()
                .HasMany(e => e.Reports)
                .WithOne(f => f.Reporter)
                .HasForeignKey(f => f.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);*/

            modelBuilder.Entity<Report>()
                .HasOne(e => e.Reporter)
                .WithMany()
                .HasForeignKey(e => e.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Report>()
                .HasOne(e => e.Investigation)
                .WithMany()
                .HasForeignKey(e => e.InvestigationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reporter>()
                .HasMany(e => e.Reports)
                .WithOne(f => f.Reporter)
                .HasForeignKey(f => f.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Investigation>()
                .HasOne(e => e.Report)
                .WithOne(f => f.Investigation)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Reporter>().HasData(
                new Reporter()
                {
                    Id = 10,
                    Name = "First",
                    Surname = "Reporter",
                    Email = "adas@gams.sca",
                    PhoneNumber = "1234567890",
                    ReportersRanking = 1
                },
                new Reporter()
                {
                    Id = 11,
                    Name = "Second",
                    Surname = "Reporter",
                    Email = "adas@gams.sca",
                    PhoneNumber = "1234567890",
                    ReportersRanking = 2
                }
            );

            modelBuilder.Entity<Report>().HasData(
                new Report()
                {
                    Id = 1,
                    DateOfReport = DateTime.UtcNow,
                    Location = "asdasd",
                    DateOfSpotting = DateTime.UtcNow,
                    TypeOfHazard = HazardTypes.Structure,
                    Description = "asdasd",
                    Status = StatusTypes.Open,
                    ImageUrl = "",
                    UpVotes = 5,
                    ReporterId = 10                  
                },
                new Report()
                {
                    Id = 2,
                    DateOfReport = DateTime.UtcNow.AddDays(-1),
                    Location = "asadsdfdvdfvdasd",
                    DateOfSpotting = DateTime.UtcNow.AddDays(-2),
                    TypeOfHazard = HazardTypes.Condition,
                    Description = "asdvsdvvsdvsasd",
                    Status = StatusTypes.Open,
                    ImageUrl = "",
                    UpVotes = 7,
                    ReporterId = 11
                }
            );

            /*modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost()
                {
                    Id = 1,
                    Title = "AGA Today",
                    Content = "Today's AGA is characterized by a series of discussions and debates around ...",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    ImageUrl = "/images/seed1.jpg",
                    CategoryId = 1
                },
                new BlogPost()
                {
                    Id = 2,
                    Title = "Traffic is incredible",
                    Content = "Today's traffic can't be described using words. Only an image can do that ...",
                    CreatedDate = DateTime.UtcNow.AddDays(-1),
                    UpdatedDate = DateTime.UtcNow.AddDays(-1),
                    ImageUrl = "/images/seed2.jpg",
                    CategoryId = 2
                },
                new BlogPost()
                {
                    Id = 3,
                    Title = "When is Spring really starting?",
                    Content = "Clouds clouds all around us. I thought spring started already, but ...",
                    CreatedDate = DateTime.UtcNow.AddDays(-2),
                    UpdatedDate = DateTime.UtcNow.AddDays(-2),
                    ImageUrl = "/images/seed3.jpg",
                    CategoryId = 3
                }
            );*/
        }

    }
}

