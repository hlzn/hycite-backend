namespace Hycite.Models;

public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public int? Gender { get; set; }
    public string? Phone { get; set; }
    public bool IsEnabled { get; set; } = true;
    public Goal? Goal { get; set; }
    public required DateOnly DateHired { get; set; }
    public required DateOnly OnboardingDate { get; set; }
    public DateOnly? OffboardingDate { get; set; }
    public AccessLevel? AccessLevel { get; set; }
    public UserType UserType { get; set; }
    public Company? Company { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int CreatedBy { get; set; }
    public int ModifiedBy { get; set; }
}