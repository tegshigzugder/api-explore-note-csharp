using ExploreNoteApi.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ExploreNoteApi.Database.Repositories;

/// <inheritdoc />
public class PlaceRepository(ExploreNoteDbContext dbContext) : IPlaceRepository
{
	/// <inheritdoc />
	public async Task<List<Place>> GetAllPlaces()
	{
		return await dbContext.Places
			.Include(p => p.PlaceReviews)
			.Include(p => p.PlaceItems)
			.ThenInclude(pl => pl.PlaceItemReviews)
			.ToListAsync();
	}

	/// <inheritdoc />
	public async Task<Place?> GetPlaceById(long nodeId)
	{
		return await dbContext.Places.FirstOrDefaultAsync(p => p.NodeId == nodeId);
	}

	/// <inheritdoc />
	public async Task AddPlace(Place place)
	{
		await dbContext.Places.AddAsync(place);
		await dbContext.SaveChangesAsync();
	}

	/// <inheritdoc />
	public async Task UpdatePlace(Place place)
	{
		dbContext.Places.Update(place);
		await dbContext.SaveChangesAsync();
	}

	/// <inheritdoc />
	public async Task DeletePlace(long NodeId)
	{
		var place = await dbContext.Places.FirstOrDefaultAsync(p => p.NodeId == NodeId);
		if (place != null)
		{
			dbContext.Places.Remove(place);
		}

		await dbContext.SaveChangesAsync();
	}
}
