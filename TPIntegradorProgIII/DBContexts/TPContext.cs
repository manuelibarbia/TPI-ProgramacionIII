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

            Meet meet1 = new Meet()
            {
                Id = 1,
                MeetDate = "20/12/2022",
                MeetName = "MeetPiola",
                MeetPlace = "Piolalandia",
            };

            Meet meet2 = new Meet()
            {
                Id = 2,
                MeetDate = "25/12/2022",
                MeetName = "MeetPiola2",
                MeetPlace = "Piolalandia",
            };

            modelBuilder.Entity<Meet>().HasData(
                meet1, meet2);

            Swimmer swimmer1 = new Swimmer()
            {
                Id = 1,
                Name = "Nicolas",
                Surname = "Bologna",
                Email = "nbologna31@gmail.com",
                Password = "123456"
            };

            Swimmer swimmer2 = new Swimmer()
            {
                Id = 2,
                Name = "Juan",
                Surname = "Perez",
                Email = "Jperez@gmail.com",
                Password = "123456"
            };

            Swimmer swimmer3 = new Swimmer()
            {
                Id = 3,
                Name = "Pedro",
                Surname = "Garcia",
                Email = "pgarcia@gmail.com",
                Password = "123456"
            };

            modelBuilder.Entity<Swimmer>().HasData(
                swimmer1, swimmer2, swimmer3);

            Trial trial1 = new Trial()
            {
                Id = 1,
                Distance = 100,
                Style = "Croll",
                MeetId = meet1.Id
            };

            Trial trial2 = new Trial()
            {
                Id = 2,
                Distance = 150,
                Style = "Croll",
                MeetId = meet2.Id
            };

            modelBuilder.Entity<Trial>().HasData(
                trial1, trial2);

            modelBuilder.Entity<Meet>()
                .HasMany<Trial>(u => u.Trials)
                .WithOne(c => c.Meet);

            modelBuilder.Entity<Trial>()
                .HasMany(x => x.RegisteredSwimmers)
                .WithMany(x => x.TrialsAttended)
                .UsingEntity(j => j
                    .ToTable("RegisteredSwimmersInTrials")
                    .HasData(new[]
                        {
                            new { RegisteredSwimmersId = 1, TrialsAttendedId = 1},
                            new { RegisteredSwimmersId = 1, TrialsAttendedId = 2},
                        }
                    ));

            //modelBuilder.Entity<Meet>()
            //    .HasMany(x => x.ParticipantSwimmers)
            //    .WithMany(x => x.MeetsAttended)
            //    .UsingEntity(j => j
            //        .ToTable("ParticipantSwimmersMeetsAttended")
            //        .HasData(new[]
            //            {
            //                new { ParticipantSwimmersId = 1, MeetsAttendedId = 4},
            //                new { ParticipantSwimmersId= 2, MeetsAttendedId = 1},
            //                new { ParticipantSwimmersId = 3, MeetsAttendedId = 2},
            //            }
            //        ));

            modelBuilder.Entity<Swimmer>()
                .HasMany(x => x.MeetsAttended)
                .WithMany(x => x.ParticipantSwimmers)
                .UsingEntity(j => j
                    .ToTable("ParticipantSwimmersInMeets")
                    .HasData(new[]
                        {
                            new { MeetsAttendedId = 2, ParticipantSwimmersId = 1, },
                            new { MeetsAttendedId= 1, ParticipantSwimmersId = 1, },
                            
                        }
                    ));
            // arreglar todas las relaciones n a n
            base.OnModelCreating(modelBuilder);
        }
    }
}
