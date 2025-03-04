namespace Hycite.Models;

public class UserSecurity
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Salt { get; set; }
    public bool WebEnabled { get; set; } = true;
    public bool AppEnabled { get; set; } = true;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public required int CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
    public int UserId { get; set; }
}