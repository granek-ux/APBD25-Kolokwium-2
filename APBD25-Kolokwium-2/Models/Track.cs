using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD25_Kolokwium_2.Models;

[Table("Track")]
public class Track
{
    [Key]
    public int TrackId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    [Precision(5,2)]
    public double LengthInKm { get; set; }

    public ICollection<TrackRace> Races { get; set; } = null!;
}