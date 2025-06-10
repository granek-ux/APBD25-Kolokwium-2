using APBD25_Kolokwium_2.Data;
using APBD25_Kolokwium_2.DTOs;
using APBD25_Kolokwium_2.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace APBD25_Kolokwium_2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ReturnDto> GetRaces(int id, CancellationToken cancellationToken)
    {
    var ret = await _context.Racers.Select(e=> new ReturnDto
        {
            RacerId = e.RacerId,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Participations = e.RaceParticipations.Select( rp => new ParticipationDto
            {
                Laps = rp.TrackRace.Laps,
                FinishTimeInSeconds = rp.FinishTimeInSeconds,
                Position = rp.Position,
                Race = new RaceDto
                {
                    Name = rp.TrackRace.Race.Name,
                    Date = rp.TrackRace.Race.Date,
                    Location = rp.TrackRace.Race.Location,
                },
                Track = new TrackDto
                {
                    Name = rp.TrackRace.Track.Name,
                    LenghtInKm = rp.TrackRace.Track.LengthInKm
                }
            }).ToList(),
        }).FirstOrDefaultAsync(e => e.RacerId == id, cancellationToken);
        if(ret is null)
            throw new NotFoundException("Racer not found");
        
        return ret;
    }
}