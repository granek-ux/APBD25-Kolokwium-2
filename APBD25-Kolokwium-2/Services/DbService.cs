using APBD25_Kolokwium_2.Data;

namespace APBD25_Kolokwium_2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
}