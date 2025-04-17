using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class MovieShopDbContext : DbContext
{
    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
    {
        
    }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Movie>(entity =>
        // {
        //     entity.Property(e => e.Title).HasColumnType("varchar(20)");
        //     entity.HasKey(e => e.Id);
        // })

        modelBuilder.Entity<Movie>(ConfigureMovie);
    }

    private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> modelBuilder)
    {
        modelBuilder.HasKey(x => new { x.MovieId, x.GenreId });
        modelBuilder.HasOne(x => x.Movie).WithMany(x => x.Genres).HasForeignKey(x => x.MovieId);
        modelBuilder.HasOne(x => x.Genre).WithMany(x => x.Movies).HasForeignKey(x => x.MovieId);

        ;
    }
    private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
    {
        // Flunet API
        builder.HasKey(m => m.Id);
        builder.Property(e => e.Title).HasColumnType("varchar(20)");
    }
}