using TPIntegradorProgIII.Entities;
using Microsoft.EntityFrameworkCore;

namespace TPIntegradorProgIII.DBContexts
{
    public class TPContext : DbContext
    {
        public DbSet<Swimmer> Swimmers { get; set; } //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
        public DbSet<Meet> Meets { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.
        public DbSet<Trial> Trials { get; set; }
        public DbSet<User> Users { get; set; }

        public TPContext(DbContextOptions<TPContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<Swimmer>().HasData(
                new Swimmer
                {
                    Surname = "Bologna",
                    Name = "Nicolas",
                    Email = "nbologna31@gmail.com",
                    Password = "123456",
                    Id = 1
                },
                new Swimmer
                {
                    Surname = "Perez",
                    Name = "Juan",
                    Email = "Jperez@gmail.com",
                    Password = "123456",
                    Id = 2
                },
                new Swimmer
                {
                    Surname = "Garcia",
                    Name = "Pedro",
                    Email = "pgarcia@gmail.com",
                    Password = "123456",
                    Id = 3
                });

            modelBuilder.Entity<Meet>().HasData(
                new Meet
                {
                    MeetName = "Encuentro 2",
                    MeetDate = "15/12/23",
                    MeetPlace = "Rosario",
                    MeetID = 4
                },
                new Meet
                {
                    MeetName = "Encuentro 1",
                    MeetDate = "10/11/23",
                    MeetPlace = "Rosario",
                    MeetID = 5
                });

            modelBuilder.Entity<Trial>().HasData(
                new Trial
                {
                    TrialID = 1,
                    Distance = 100,
                    Style = "Croll"
                },
                new Trial
                {
                    TrialID = 2,
                    Distance = 150,
                    Style = "Croll"
                });

            modelBuilder.Entity<Meet>()
                .HasMany<Trial>(u => u.Trials)
                .WithOne(c => c.Meet);

            modelBuilder.Entity<Trial>()
                .HasMany(x => x.RegisteredSwimmers)
                .WithMany(x => x.TrialsAttended)
                .UsingEntity(j => j
                    .ToTable("RegisteredSwimmersTrialsAttended")
                    .HasData(new[]
                        {
                            new { RegisteredSwimmersId = 1, TrialsAttendedId = 1},
                            new { RegisteredSwimmersId = 1, TrialsAttendedId = 2},
                        }
                    ));

            modelBuilder.Entity<Meet>()
                .HasMany(x => x.ParticipantSwimmers)
                .WithMany(x => x.MeetsAttended)
                .UsingEntity(j => j
                    .ToTable("ParticipantsSwimmersMeetsAttended")
                    .HasData(new[]
                        {
                            new { ParticipantSwimmersId = 4, MeetsAttendedId = 1},
                            new { ParticipantSwimmersId= 5, MeetsAttendedId = 1},
                            new { ParticipantSwimmersId = 4, MeetsAttendedId = 2},
                        }
                    ));

            base.OnModelCreating(modelBuilder);
        }
    }
}
