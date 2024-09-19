using Microsoft.EntityFrameworkCore;
using PackApi.Models.Database;

namespace FernwehApi.Database.Models;
public class FernwehDbContext : DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<Place> Places { get; set; }
	public DbSet<PlaceReview> PlaceReviews { get; set; }
	public DbSet<PlaceItem> PlaceItems { get; set; }
	public DbSet<PlaceItemReview> PlaceItemReviews { get; set; }
	public DbSet<Photo> Photos { get; set; }
	public DbSet<Friend> Friends { get; set; }
	public string DbPath { get; }

	public FernwehDbContext()
	{
		var baseDirectory = AppContext.BaseDirectory;

		var projectDirectory = System.IO.Directory.GetParent(baseDirectory).Parent.Parent.Parent.Parent.FullName;
		var dbFolder = System.IO.Path.Join(projectDirectory, "Database");
		DbPath = System.IO.Path.Join(dbFolder, "fernweh.db");
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlite($"Data Source={DbPath}");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<User>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
			entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
			entity.HasIndex(e => e.Username).IsUnique();
			entity.HasIndex(e => e.Email).IsUnique();
		});

		modelBuilder.Entity<Place>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
			entity.Property(e => e.Location).IsRequired();
			entity.Property(e => e.NodeId).IsRequired();
			entity.HasIndex(e => e.NodeId).IsUnique();
		});

		modelBuilder.Entity<PlaceReview>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Rating).IsRequired();
			entity.Property(e => e.Comment).IsRequired();
		});

		modelBuilder.Entity<PlaceItem>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
			entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
		});

		modelBuilder.Entity<PlaceItemReview>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Rating).IsRequired();
			entity.Property(e => e.Comment).IsRequired();
		});

		modelBuilder.Entity<Photo>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Url).IsRequired();
		});

		modelBuilder.Entity<Friend>(entity =>
		{
			entity.HasKey(e => e.Id);
		});
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		ChangeTracker.Entries()
			.Where(entry => entry.State == EntityState.Added)
			.Select(entry => entry.Entity)
			.ToList()
			.ForEach(entry =>
			{
				if (entry is AuditableEntity auditableEntity)
					auditableEntity.ModifiedAt = auditableEntity.CreatedAt = DateTime.Now;
			});

		ChangeTracker.Entries()
			.Where(entry => entry.State == EntityState.Modified)
			.Select(entry => entry.Entity)
			.ToList()
			.ForEach(entry =>
			{
				if (entry is AuditableEntity auditableEntity)
					auditableEntity.ModifiedAt = DateTime.Now;
			});

		return base.SaveChangesAsync(cancellationToken);
	}
}
