﻿using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Movie
{
    public int Id { get; set; }
    [MaxLength(512)]
    public string? Title { get; set; }
    public string? Overview { get; set; }
    public string? TagLine { get; set; }
    public decimal Budget { get; set; }
    public decimal Revenue { get; set; }
    public string? ImdbUrl { get; set; }
    public string? PosterUrl { get; set; }
    public string? BackdropUrl { get; set; }
    public string? OriginalLanguage { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int? Runtime { get; set; }
    public decimal? Price { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? TmdbUrl { get; set; }

    public string? UpdatedBy { get; set; }
    public string? CreatedBy { get; set; }
    
    // Navigation property
    public ICollection<Trailer> Trailers { get; set; }
    public ICollection<MovieGenre> MovieGenres { get; set; }
    public ICollection<MovieCast> MovieCasts { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Purchase> Purchases { get; set; }
    public ICollection<Favorite> Favorites { get; set; }
}