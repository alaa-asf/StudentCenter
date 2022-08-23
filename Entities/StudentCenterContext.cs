using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace StudentCenter.Entities
{
    public class StudentCenterContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbSet<Center_Record>? Center_Records { get; set; }
        public DbSet<Collage>? Collages { get; set; }
        public DbSet<Collage_Record>? Collage_Records { get; set; }
        public DbSet<Demand>? Demands { get; set; }

        public DbSet<Service>? Services { get; set; }
        public DbSet<Service_Document_Required>? Service_Document_Requireds { get; set; }
        public DbSet<Student_Demand>? Student_Demands { get; set; }
        public DbSet<User>? Users { get; set; }



        public StudentCenterContext()
        {
        }



        public StudentCenterContext(string connectionString) : base(GetOptions(connectionString))
        {
        }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }


        public StudentCenterContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
        }


      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}