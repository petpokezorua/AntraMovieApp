namespace ApplicationCore.Entities;

public class Role
{
    public int id { get; set; }
    public string name { get; set; }
    
    // Navigation
    public ICollection<UserRole>  UserRoles { get; set; }
}