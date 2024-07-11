using Exam_Dashboard.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam_Dashboard.Api.DBContext
{
    public class AppDBContext:IdentityDbContext<User>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = localhost; Database = ExamDashboardDB; Trusted_Connection = True; MultipleActiveResultSets = True; TrustServerCertificate = True;");

        //}

        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamPupil> ExamPupils  { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");


            builder.Entity<Pupil>(entity =>
            {

                entity.Property(e => e.FirstName)
                .HasColumnType("varchar(30)")
                .IsRequired();
                entity.Property(e => e.LastName)
                .HasColumnType("varchar(30)")
                .IsRequired();
            });
            builder.Entity<Lesson>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.LessonCode)
                    .HasColumnType("char(3)")

                    .IsRequired();

                entity.Property(e => e.LessonName)
                 .HasColumnType("varchar(30)")
                    .IsRequired();


                entity.Property(e => e.TeacherFirstName)
                    .HasColumnType("varchar(20)")
                    .IsRequired();
                entity.Property(e => e.TeacherLastName)
                 .HasColumnType("varchar(20)")
                 .IsRequired();
            });
            builder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.LessonCode)
                    .HasColumnType("char(3)")

                    .IsRequired();





            });


        }
    }
}
