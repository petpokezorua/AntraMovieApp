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
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Cast> Casts { get; set; }
    public DbSet<MovieCast> MovieCasts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(ConfigureMovie);
        modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
        modelBuilder.Entity<Favorite>(ConfigureFavorite);
        modelBuilder.Entity<Review>(ConfigureReview);
        modelBuilder.Entity<Purchase>(ConfigurePurchase);
        modelBuilder.Entity<UserRole>(ConfigureUserRole);
        modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
    }

    private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> modelBuilder)
    {
        modelBuilder.HasKey(mc => new { mc.MovieId, mc.CastId });

        modelBuilder.HasOne(mc => mc.Movie)
            .WithMany(m => m.MovieCasts)
            .HasForeignKey(mc => mc.MovieId);

        modelBuilder.HasOne(mc => mc.Cast)
            .WithMany(c => c.MovieCasts)
            .HasForeignKey(mc => mc.CastId);
    }

    private void ConfigureUserRole(EntityTypeBuilder<UserRole> modelBuilder)
    {
        modelBuilder.HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
    }

    private void ConfigurePurchase(EntityTypeBuilder<Purchase> modelBuilder)
    {
        modelBuilder.HasKey(p => new { p.MovieId, p.UserId });

        modelBuilder.HasOne(p => p.Movie)
            .WithMany(m => m.Purchases)
            .HasForeignKey(p => p.MovieId);

        modelBuilder.HasOne(p => p.User)
            .WithMany(u => u.Purchases)
            .HasForeignKey(p => p.UserId);
    }

    private void ConfigureReview(EntityTypeBuilder<Review> modelBuilder)
    {
        modelBuilder.HasKey(r => new { r.MovieId, r.UserId });

        modelBuilder.HasOne(r => r.Movie)
            .WithMany(m => m.Reviews)
            .HasForeignKey(r => r.MovieId);

        modelBuilder.HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);
    }

    private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> modelBuilder)
    {
        modelBuilder.HasKey(x => new { x.MovieId, x.GenreId });

        modelBuilder.HasOne(x => x.Movie)
            .WithMany(m => m.MovieGenres)
            .HasForeignKey(x => x.MovieId);

        modelBuilder.HasOne(x => x.Genre)
            .WithMany(g => g.MovieGenres)
            .HasForeignKey(x => x.GenreId);
    }
    
    private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
    {
        // Flunet API
        builder.HasKey(m => m.Id);
        builder.Property(e => e.Title).HasColumnType("varchar(20)");
    }
    
    private void ConfigureFavorite(EntityTypeBuilder<Favorite> modelBuilder)
    {
        modelBuilder.HasKey(f => new { f.MovieId, f.UserId });

        modelBuilder.HasOne(f => f.Movie)
            .WithMany(m => m.Favorites)
            .HasForeignKey(f => f.MovieId);

        modelBuilder.HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UserId);
    }
}