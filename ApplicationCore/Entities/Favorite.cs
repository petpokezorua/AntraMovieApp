namespace ApplicationCore.Entities;

public class Favorite
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    
    // Navigation
    public Movie Movie { get; set; }
    public User User { get; set; }
}