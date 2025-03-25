using Hycite.Models;

namespace Hycite.DTOs;

public class UserActivityDTO
{
    public required DateTime ActivityDate { get; set; }
    public required int ProspectSourceId { get; set; }
    public bool Appointment { get; set; } = false;
    public bool Demonstration { get; set; } = false;
    public decimal Sale { get; set; } = 0.00m;
}