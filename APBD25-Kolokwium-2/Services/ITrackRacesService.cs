using APBD25_Kolokwium_2.DTOs;

namespace APBD25_Kolokwium_2.Services;

public interface ITrackRacesService
{
    public Task PutRacer(RequiredDto requiredDto, CancellationToken cancellationToken);
}