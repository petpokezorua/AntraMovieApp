namespace ApplicationCore.Entities;

public class MovieGenre
{
    public int GenreId { get; set; }
    public int MovieId { get; set; }
    
    // Navigation property
    public Movie Movie { get; set; }
    public Genre Genre { get; set; }
}