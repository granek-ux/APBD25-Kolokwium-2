using APBD25_Kolokwium_2.DTOs;

namespace APBD25_Kolokwium_2.Services;

public interface IDbService
{
    public Task<ReturnDto> GetRaces(int id, CancellationToken cancellationToken);

}