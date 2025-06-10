using APBD25_Kolokwium_2.Data;
using APBD25_Kolokwium_2.DTOs;
using APBD25_Kolokwium_2.Exceptions;
using APBD25_Kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD25_Kolokwium_2.Services;

public class TrackRacesService : ITrackRacesService
{
    private readonly DatabaseContext _context;

    public TrackRacesService(DatabaseContext context)
    {
        _context = context;
    }


    public async Task PutRacer(RequiredDto requiredDto, CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var race = await _context.Races.FirstOrDefaultAsync(e => e.Name == requiredDto.RaceName, cancellationToken);

            if (race is null)
                throw new NotFoundException($"Race with name {requiredDto.RaceName} was not found");

            var track = await _context.Tracks.FirstOrDefaultAsync(e => e.Name == requiredDto.TrackName, cancellationToken);

            if (track is null)
                throw new NotFoundException($"Track with name {requiredDto.TrackName} was not found");

            var trackRace = await _context.TrackRaces.Where(e => e.RaceId == race.RaceId && e.TrackId == track.TrackId)
                .FirstOrDefaultAsync(cancellationToken);

            if (trackRace is null)
                throw new NotFoundException("TrackRace  was not found");

            foreach (var participations in requiredDto.Participations)
            {
                var racer = await _context.Racers.FirstOrDefaultAsync(e => e.RacerId == participations.RacerId,
                    cancellationToken);

                if (racer is null)
                    throw new NotFoundException($"Racer with name {requiredDto.TrackName} was not found");

                var raceParticipation = new RaceParticipation
                {
                    TrackRaceId = trackRace.TrackRaceId,
                    RacerId = racer.RacerId,
                    FinishTimeInSeconds = participations.FinishTimeInSeconds,
                    Position = participations.Position,
                    TrackRace = trackRace,
                    Racer = racer
                };
                
                if (trackRace.BestTimeInSeconds < participations.FinishTimeInSeconds)
                    trackRace.BestTimeInSeconds = participations.FinishTimeInSeconds;
            }


            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}