using ExploreNoteApi.Database.Models;

namespace ExploreNoteApi.Database.Repositories;

public class PlacesDbRepository(ExploreNoteDbContext dbContext) : IPlacesDbRepository
{
	public async Task Save(List<Place> listPlaces)
	{
		await dbContext.Places.AddRangeAsync(listPlaces);
	}
}
