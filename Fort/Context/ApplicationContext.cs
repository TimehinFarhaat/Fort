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
            modelBuilder.Entity<PatientCheckup>().HasKey(pc => pc.Id);
            modelBuilder.Entity<SymptomCheckup>().HasKey(u => u.Id);

            modelBuilder.Entity<User>().HasMany<View>(c => c.Views);
            modelBuilder.Entity<View>().HasOne<User>(c => c.User);  

            modelBuilder.Entity<PatientCheckup>().HasOne<Patient>(c => c.Patient).WithMany(s => s.PatientCheckup).HasForeignKey(d => d.PatientId);

            modelBuilder.Entity<PatientCheckup>().HasOne<CheckUp>(c => c.Checkup).WithMany(s => s.PatientCheckups).HasForeignKey(d => d.CheckUpId);
            modelBuilder.Entity<User>().HasIndex(p => p.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(p => p.Id).IsUnique();

            var user = new User
            {
                Id = 1,
                Email = "maryam@mail.com",
                Gender = "Female",
                Age=64,
                PhoneNumber="0804675464",
                PassWord = BCrypt.Net.BCrypt.HashPassword("12345"),

            };

            var rol = new Role
            {
                Id = 1,
                Name = "Admin",
                Description = "Administrator"
            };
            var Userrol = new UserRole
            {
                Id = 1,
                RoleId = rol.Id,

                UserId = user.Id,
            };


            var admin = new Admin
            {
                Id = 1,
                UserId = user.Id,
                FirstName="Ada",
                LastName="Obi",
                CreatedOn = DateTime.Now,
                CreatedBy = user.Id,
                LastModifiedBy = user.Id,
                LastModifiedOn = DateTime.Now,
                IsDeleted = false
            };


            modelBuilder.Entity<Role>(u => u.HasData(rol));
            modelBuilder.Entity<Admin>(u => u.HasData(admin));
            modelBuilder.Entity<User>(u => u.HasData(user));
            modelBuilder.Entity<UserRole>(u => u.HasData(Userrol));
        }
    
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles{ get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientCheckup> PatientCheckups { get; set; }
        public DbSet<CheckUp> CheckUps { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<View> Views { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<SymptomCheckup> SymptomCheckups{ get; set; }
   
    
      
    }
}
