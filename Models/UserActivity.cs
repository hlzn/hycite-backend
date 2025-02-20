namespace Hycite.Models;

public class UserActivity
{
    public int Id { get; set; }
    public required DateTime ActivityDate { get; set; }
    public required ProspectSource Source { get; set; }
    public bool Appointment { get; set; } = false;
    public bool Demonstration { get; set; } = false;
    public decimal Sale { get; set; } = 0.00m;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public required int CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
}