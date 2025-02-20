namespace Hycite.Models;

public class Goal
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Period { get; set; }
    public required int Appointments { get; set; }
    public required int Demonstrations { get; set; }
    public required int Sales { get; set; }
    public required int Tickets { get; set; }
    public required int Candidates { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public required int CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
}