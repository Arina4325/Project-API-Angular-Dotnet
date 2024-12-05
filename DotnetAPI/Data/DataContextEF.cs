using System.Data;
using Microsoft.EntityFrameworkCore;
using DotnetAPI.Models;



namespace DotnetAPI.Data
{
    public class DataContextEF : DbContext
    {
        private readonly IConfiguration _config;
        public DataContextEF(IConfiguration config)
        {
            _config = config;

        }

        public virtual DbSet<User> Users {get; set;}

        public virtual DbSet<UserSalary> UserSalary {get; set;}

        public virtual DbSet<UserJobInfo> UserJobInfo {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                        optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasDefaultSchema("TutorialAppSchema");
           
            modelBuilder.Entity<User>()
                .ToTable("Users", "TutorialAppSchema") //models name is User, name of Table in DB is Users - we have to tell to entity what name of Table we are using for
                .HasKey(u => u.UserId);

                modelBuilder.Entity<UserSalary>()
                .HasKey(u => u.UserId);

                modelBuilder.Entity<UserJobInfo>()
                 .HasKey(u => u.UserId);
        }





    }
}