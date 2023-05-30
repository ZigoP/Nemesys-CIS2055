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
                Name = "Patrik",
                Surname = "Reporter",
                UserName = "patrikzigo@gmail.com",
                NormalizedUserName = "PATRIKZIGO@GMAIL.COM",
                Email = "patrikzigo@gmail.com",
                NormalizedEmail = "PATRIKZIGO@GMAIL.COM",
                PhoneNumber = "+356 91821310",
                ReportersRanking = 1,
                LockoutEnabled = false,
                EmailConfirmed = true,
            };


            Reporter reporter2 = new Reporter()
            {
                Id = "secondReporterId",
                Name = "Ali",
                Surname = "Reporter",
                UserName = "beyalibulut@gmail.com",
                NormalizedUserName = "BEYALIBULUT@GMAIL.COM",
                Email = "beyalibulut@gmail.com",
                NormalizedEmail = "BEYALIBULUT@GMAIL.COM",
                PhoneNumber = "+356 99780821",
                ReportersRanking = 2,
                LockoutEnabled = false,
                EmailConfirmed = true,
            };          

            PasswordHasher<Reporter> passwordHasher = new PasswordHasher<Reporter>();
            reporter1.PasswordHash = passwordHasher.HashPassword(reporter1, "S@fePassw0rd1"); 

            PasswordHasher<Reporter> passwordHasher2 = new PasswordHasher<Reporter>();
            reporter2.PasswordHash = passwordHasher2.HashPassword(reporter2, "S@fePassw0rd2"); 
                                                                                               

            modelBuilder.Entity<Reporter>().HasData(
                reporter1,
                reporter2
           );

            Investigator investigator = new Investigator()
            {
                Id = "firstInvestigatorId",
                Name = "Michael",
                Surname = "Investigator",
                UserName = "michael@gmail.com",
                NormalizedUserName = "MICHAEL@GMAIL.COM",
                Email = "michael@gmail.com",
                NormalizedEmail = "MICHAEL@GMAIL.COM",
                PhoneNumber = "+356 91286821",
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
                    Name = "Pool is broken",
                    DateOfReport = DateTime.UtcNow,
                    Location = "Campus Hub Piazza",
                    DateOfSpotting = DateTime.UtcNow,
                    TypeOfHazard = HazardTypes.Structure,
                    Description = "Pool in the Campus Hub is Broken. Don't ask how. Its just broken",
                    Status = StatusTypes.Open,
                    ImageUrl = "https://media.istockphoto.com/id/521812033/photo/lawn-chairs-overlooking-backyard-and-swimming-pool.jpg?s=1024x1024&w=is&k=20&c=IZd3LZBnIwn4PB8zuZxzOjB95jpPqH5kcxH9V1cygBc=",
                    UpVotes = 5,
                    ReporterId = reporter1.Id
                },
                new Report()
                {
                    Id = 2,
                    Name = "Fallen tree in the middle of campus",
                    DateOfReport = DateTime.UtcNow.AddDays(-1),
                    Location = "Campus Quads",
                    DateOfSpotting = DateTime.UtcNow.AddDays(-2),
                    TypeOfHazard = HazardTypes.UnsafeAct,
                    Description = "One of the tree's in Quads fell down",
                    Status = StatusTypes.Open,
                    ImageUrl = "https://images.freeimages.com/images/large-previews/3c2/victim-of-a-storm-2-1638820.jpg",
                    UpVotes = 7,
                    ReporterId = reporter2.Id              
                }
            );
                
        }

    }
}

