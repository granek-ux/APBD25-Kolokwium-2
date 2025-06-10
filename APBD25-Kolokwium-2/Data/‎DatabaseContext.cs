using APBD25_Kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD25_Kolokwium_2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Race> Races { get; set; }
    public DbSet<RaceParticipation> RaceParticipations { get; set; }
    public DbSet<Racer> Racers { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Race>().HasData(new List<Race>()
        {
            new Race() { RaceId = 1, Location = "tu", Date = DateTime.Now, Name = "Name" }
        });

        modelBuilder.Entity<Track>().HasData(new List<Track>()
        {
            new Track() { TrackId = 1, Name = "Name", LengthInKm = 5 }
        });

        modelBuilder.Entity<Racer>().HasData(new List<Racer>()
        {
            new Racer() { RacerId = 1, FirstName = "Name", LastName = "Name" },
            new Racer() { RacerId = 2, FirstName = "Name", LastName = "Name" }
        });

        modelBuilder.Entity<TrackRace>().HasData(new List<TrackRace>()
        {
            new TrackRace(){TrackRaceId = 1,RaceId = 1, TrackId = 1, Laps = 54, BestTimeInSeconds = 14}
        });
        modelBuilder.Entity<RaceParticipation>().HasData(new List<RaceParticipation>()
        {
            new RaceParticipation(){ TrackRaceId = 1, RacerId = 1, FinishTimeInSeconds = 14, Position = 1}
        });
    }
}