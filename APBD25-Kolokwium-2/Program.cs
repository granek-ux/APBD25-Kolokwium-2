using APBD25_Kolokwium_2.Data;
using APBD25_Kolokwium_2.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB"))
);


builder.Services.AddScoped<IDbService, DbService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.DocExpansion(DocExpansion.List);
        c.DefaultModelExpandDepth(0);
        c.DisplayRequestDuration();
        c.EnableFilter();
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();

// dotnet ef migrations add Init - tworzenie migracji
// dotnet ef database update - aktualizacja bazy danych
// dotnet ef migrations remove - usuwanie ostatniej migracji