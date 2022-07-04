using Fort.Model;
using Fort.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fort.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "Maryam",
                PassWord = "May",
                Email = "mary@mail.com",
                CreatedOn = DateTime.Now,
                CreatedBy =1990,
                IsDeleted = false,

            });

            modelBuilder.Entity<Role>().Property(u => u.Name).IsRequired();

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                Description = "Administrator",
                CreatedBy = 1,
                IsDeleted = false,
                LastModifiedBy = 1,
                CreatedOn=DateTime.Now,
                LastModifiedOn=DateTime.Now, 
            });


            modelBuilder.Entity<User_role>().HasData(new User_role
            {
                Id=1,
                CreatedOn=DateTime.Now,
                ApplicationRoleId = 1,
                ApplicationUserId = 1,
                CreatedBy=1,
                LastModifiedBy=1,
                IsDeleted=false,
                LastModifiedOn=DateTime.Now,
                
            });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_role> UserRoles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientCheckup> PatientSymptoms { get; set; }
        public DbSet<CheckUp> checkUps { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Symptom> symptoms { get; set; }
    }
}
