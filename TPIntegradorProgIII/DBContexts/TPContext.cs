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
                Password = "123456",
                UserName = "NicoBo",
                DNI = "44539210"
            };

            Swimmer swimmer2 = new Swimmer()
            {
                Id = 2,
                Name = "Juan",
                Surname = "Perez",
                Email = "Jperez@gmail.com",
                Password = "123456",
                UserName = "JuanPe",
                DNI = "33444555"
            };

            Swimmer swimmer3 = new Swimmer()
            {
                Id = 3,
                Name = "Pedro",
                Surname = "Garcia",
                Email = "pgarcia@gmail.com",
                Password = "123456",
                UserName = "PeGarcía",
                DNI = "55666777"
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
