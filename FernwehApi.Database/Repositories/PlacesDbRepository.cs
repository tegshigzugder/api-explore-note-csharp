using FernwehApi.Database.Models;


namespace FernwehApi.Repositories;
public class PlacesDbRepository : IPlacesDbRepository
{
	private readonly FernwehDbContext _dbContext;

	public PlacesDbRepository(FernwehDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task Save(List<Place> listPlaces)
	{
		await _dbContext.Places.AddRangeAsync(listPlaces);
	}
}
