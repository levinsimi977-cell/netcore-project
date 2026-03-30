using Microsoft.EntityFrameworkCore;
using MusicSimi.Core.Entities;
using MusicSimi.Entities;

namespace MusicSimi
{
    public class DataConext : DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SchooL3");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.Property(e => e.Role)
                    .HasConversion(
                        v => v.ToString(), // המרה לstring
                        v => Enum.Parse<eRole>(v)); // המרה חזרה לenum
            });
            modelBuilder.Entity<Students>()
        .HasMany(s => s.lessons)
        .WithMany(l => l.students)
        .UsingEntity<Dictionary<string, object>>(
            "LessonsStudents",
            j => j
                .HasOne<Lessons>()
                .WithMany()
                .HasForeignKey("LessonsId")
                .OnDelete(DeleteBehavior.Cascade),
            j => j
                .HasOne<Students>()
                .WithMany()
                .HasForeignKey("StudentsId")
                .OnDelete(DeleteBehavior.Restrict)
        );
        }
    }
}
//Server=(localdb)\MSSQLLocalDB;port=123;userName=Poi;Password=12345;Database=School