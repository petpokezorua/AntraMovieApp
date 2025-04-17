using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Trailer
{
    public int Id { get; set; }
    [MaxLength(256)]
    public string TrailerURL { get; set; }
    [MaxLength(256)]
    public string Name { get; set; }
    // Foreign key 
    [ForeignKey("Movies")]
    public int MovieId { get; set; }
    // Navigation property
    public Movie Movie { get; set; }
}