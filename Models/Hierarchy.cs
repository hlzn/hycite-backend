namespace Hycite.Models;

public class Hierarchy
{
    public int ParentId { get; set; }
    public int ChildId { get; set; }
    public bool IsEnabled { get; set; } = true;
}