namespace APBD25_Kolokwium_2.DTOs;

public class ReturnDto
{
    public int RacerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; }= null!;
    public ICollection<ParticipationDto> Participations { get; set; }= null!;
}

public class ParticipationDto
{
    public RaceDto Race { get; set; }= null!;
    public TrackDto Track { get; set; }= null!;
    public int Laps { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}

public class RaceDto
{
    public string Name { get; set; }= null!;
    public string Location { get; set; }= null!;
    public DateTime Date { get; set; }
}

public class TrackDto
{
    public string Name { get; set; }= null!;
    public double LenghtInKm { get; set; }
}