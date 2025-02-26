using ExploreNoteApi.Database.Models;

namespace ExploreNoteApi.Database.Repositories;

public class PlacesDbRepository : IPlacesDbRepository
{
	private readonly ExploreNoteDbContext _dbContext;

	public PlacesDbRepository(ExploreNoteDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task Save(List<Place> listPlaces)
	{
		await _dbContext.Places.AddRangeAsync(listPlaces);
	}
}
