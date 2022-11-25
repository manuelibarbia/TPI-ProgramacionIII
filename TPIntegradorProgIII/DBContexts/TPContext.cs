using TPIntegradorProgIII.Entities;
using Microsoft.EntityFrameworkCore;

namespace TPIntegradorProgIII.DBContexts
{
    public class TPContext : DbContext
    {
        public DbSet<Swimmer> Swimmers { get; set; } //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
        public DbSet<Meet> Meets { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.
        public DbSet<Trial> Trials { get; set; }

        public TPContext(DbContextOptions<TPContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Meet meet1 = new Meet()
            {
                Id = 1,
                MeetDate = "20-12-2022",
                MeetName = "Primer Meet",
                MeetPlace = "Rosario",
            };

            Meet meet2 = new Meet()
            {
                Id = 2,
                MeetDate = "25-12-2022",
                MeetName = "Segundo Meet",
                MeetPlace = "Buenos Aires",
            };

            modelBuilder.Entity<Meet>().HasData(
                meet1, meet2);

            Trial trial1 = new Trial()
            {
                Id = 1,
                Distance = 100,
                Style = "Croll",
                MeetId = meet1.Id,
                MeetName = meet1.MeetName
            };

            Trial trial2 = new Trial()
            {
                Id = 2,
                Distance = 150,
                Style = "Espalda",
                MeetId = meet2.Id,
                MeetName = meet2.MeetName
            };

            modelBuilder.Entity<Trial>().HasData(
                trial1, trial2);

            Swimmer swimmer1 = new Swimmer()
            {
                Id = 1,
                Name = "Manuel",
                Surname = "Ibarbia",
                Email = "manuel@gmail.com",
                Password = "string",
                UserName = "string",
                DNI = 44555666,
                TrialId = trial1.Id,
                AttendedTrial = trial1.Style + " " + trial1.Distance + " metros" + " (" + trial1.MeetName + ")"
            };

            Swimmer swimmer2 = new Swimmer()
            {
                Id = 2,
                Name = "Luciano",
                Surname = "Solari",
                Email = "luciano@gmail.com",
                Password = "123456",
                UserName = "lucianoS",
                DNI = 33444555,
                TrialId = trial1.Id,
                AttendedTrial = trial1.Style + " " + trial1.Distance + " metros" + " (" + trial1.MeetName + ")"
            };

            Swimmer swimmer3 = new Swimmer()
            {
                Id = 3,
                Name = "Santiago",
                Surname = "Caso",
                Email = "santiago@gmail.com",
                Password = "123456",
                UserName = "santiagoC",
                DNI = 55666777,
                TrialId = trial2.Id,
                AttendedTrial = trial2.Style + " " + trial2.Distance + " metros" + " (" + trial2.MeetName + ")"
            };

            modelBuilder.Entity<Swimmer>().HasData(
                swimmer1, swimmer2, swimmer3);

            modelBuilder.Entity<Meet>()
                .HasMany<Trial>(m => m.Trials)
                .WithOne(t => t.Meet);

            modelBuilder.Entity<Trial>()
                .HasMany<Swimmer>(t => t.RegisteredSwimmers)
                .WithOne(s => s.Trial);

            base.OnModelCreating(modelBuilder);
        }
    }
}
