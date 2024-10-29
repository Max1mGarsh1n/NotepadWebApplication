using Microsoft.EntityFrameworkCore;
using NotepadWebApp.DataAccess.Entities;

namespace NotepadWebApp.DataAccess;

public class NotepadDbContext : DbContext
{
    public NotepadDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserEntity> Countries { get; set; }
    public DbSet<TagEntity> Towns { get; set; }
    public DbSet<NoteTagEntity> Users { get; set; }
    public DbSet<NoteEntity> Tickets { get; set; }
    public DbSet<CategoryEntity> Airports { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<UserEntity>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<UserEntity>()
            .HasMany(n => n.Notes) 
            .WithOne(n => n.User)
            .HasForeignKey(n => n.UserId);
        
        modelBuilder.Entity<NoteEntity>()
            .HasKey(n => n.Id);

        modelBuilder.Entity<NoteEntity>()
            .HasMany(nt => nt.NoteTags) 
            .WithOne(nt => nt.Note)
            .HasForeignKey(nt => nt.NoteId);
        
        modelBuilder.Entity<TagEntity>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<TagEntity>()
            .HasMany(nt => nt.NoteTags)
            .WithOne(nt => nt.Tag)
            .HasForeignKey(nt => nt.TagId);
        
        modelBuilder.Entity<CategoryEntity>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<CategoryEntity>()
            .HasMany(n => n.Notes) 
            .WithOne(n => n.Category)
            .HasForeignKey(n => n.CategoryId);
    }
}