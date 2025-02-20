namespace Hycite.Models;

public class Company
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public required int CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
}