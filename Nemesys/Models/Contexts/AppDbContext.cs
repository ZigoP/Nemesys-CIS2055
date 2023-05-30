using Microsoft.AspNetCore.Identity;
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
        public DbSet<IdentityUserRole<string>> IdentityUserRoles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //IMPORTANT: Required to setup the schema for the identity framework
            base.OnModelCreating(modelBuilder);

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


            Reporter reporter1 = new Reporter()
            {
                Id = "firstReporterId",
                Name = "First",
                Surname = "Reporter",
                UserName = "adas@gams.sca",
                NormalizedUserName = "ADAS@GAMS.SCA",
                Email = "adas@gams.sca",
                NormalizedEmail = "ADAS@GAMS.SCA",
                PhoneNumber = "1234567890",
                ReportersRanking = 1,
                LockoutEnabled = false,
                EmailConfirmed = true,
            };


            Reporter reporter2 = new Reporter()
            {
                Id = "secondReporterId",
                Name = "Second",
                Surname = "Reporter",
                UserName = "basd@gams.sca",
                NormalizedUserName = "BASD@GAMS.SCA",
                Email = "basd@gams.sca",
                NormalizedEmail = "BASD@GAMS.SCA",
                PhoneNumber = "1234567890",
                ReportersRanking = 2,
                LockoutEnabled = false,
                EmailConfirmed = true,
            };          

            PasswordHasher<Reporter> passwordHasher = new PasswordHasher<Reporter>();
            reporter1.PasswordHash = passwordHasher.HashPassword(reporter1, "S@fePassw0rd1"); //make sure you adhere to policies (incl confirmed etc…)
            //modelBuilder.Entity<Reporter>().HasData(reporter1);

            PasswordHasher<Reporter> passwordHasher2 = new PasswordHasher<Reporter>();
            reporter2.PasswordHash = passwordHasher2.HashPassword(reporter2, "S@fePassw0rd2"); //make sure you adhere to policies (incl confirmed etc…)
                                                                                               //modelBuilder.Entity<Reporter>().HasData(reporter2);

            modelBuilder.Entity<Reporter>().HasData(
                reporter1,
                reporter2
           );

            Investigator investigator = new Investigator()
            {
                Id = "firstInvestigatorId",
                Name = "First",
                Surname = "Investigator",
                UserName = "dasd@gams.sca",
                NormalizedUserName = "DASD@GAMS.SCA",
                Email = "dasd@gams.sca",
                NormalizedEmail = "DASD@GAMS.SCA",
                PhoneNumber = "1234567890",
                ReportersRanking = 3,
                LockoutEnabled = false,
                EmailConfirmed = true,
            };

            PasswordHasher<Investigator> passwordHasher3 = new PasswordHasher<Investigator>();
            investigator.PasswordHash = passwordHasher3.HashPassword(investigator, "S@fePassw0rd3");

            modelBuilder.Entity<Investigator>().HasData(
                investigator
            );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "adminRoleId", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "reporterRoleId", Name = "Reporter", ConcurrencyStamp = "1", NormalizedName = "REPORTER" },
                new IdentityRole() { Id = "investigatorRoleId", Name = "Invetigator", ConcurrencyStamp = "1", NormalizedName = "INVESTIGATOR" }
            );

            //Assign existing user to admin role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "reporterRoleId", UserId = "firstReporterId" },
                new IdentityUserRole<string>() { RoleId = "reporterRoleId", UserId = "secondReporterId" },
                new IdentityUserRole<string>() { RoleId = "investigatorRoleId", UserId = "firstInvestigatorId" }
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
                    ReporterId = reporter1.Id
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
                    ReporterId = reporter2.Id
                }
            );
                
        }

    }
}

