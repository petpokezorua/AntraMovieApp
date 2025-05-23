﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

[Table("Genres")]
public class Genre
{
    public int Id { get; set; }
    [MaxLength(64)]
    public string Name { get; set; }
    
    // Navigation Property
    public ICollection<MovieGenre> MovieGenres { get; set; }
}