using System.ComponentModel.DataAnnotations;

namespace APBD25_Kolokwium_2.DTOs;

public class RequiredDto
{
    [Required]
    [MaxLength(50)]
    public string RaceName { get; set; }
    [Required]
    [MaxLength(100)]
    public string TrackName { get; set; }
    [Required]
    public ICollection<RequieredParticipationsDto> Participations { get; set; }
    
    
}

public class RequieredParticipationsDto
{
    [Required]
    public int RacerId { get; set; }
    [Required]
    public int Position { get; set; }
    [Required]
    public int FinishTimeInSeconds { get; set; }
}