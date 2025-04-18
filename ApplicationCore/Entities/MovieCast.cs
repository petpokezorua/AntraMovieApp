using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;


public class MovieCast
{
    public int CastId { get; set; }
    public int MovieId { get; set; }
    public string Character { get; set; }
    
    // Navigation:
    public Movie Movie { get; set; }
    public Cast Cast { get; set; }
}