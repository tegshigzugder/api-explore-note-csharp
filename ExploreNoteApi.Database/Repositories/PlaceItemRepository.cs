using ExploreNoteApi.Database.Models;

namespace ExploreNoteApi.Database.Repositories;

public class PlaceItemRepository(ExploreNoteDbContext dbContext) : IPlaceItemRepository
{
	public async Task AddPlaceItemAsync(PlaceItem item)
	{
		await dbContext.PlaceItems.AddAsync(item);
		await dbContext.SaveChangesAsync();
	}

	public async void RemovePlaceItem(PlaceItem item)
	{
		dbContext.PlaceItems.Remove(item);
		await dbContext.SaveChangesAsync();
	}

	public PlaceItem GetPlaceItemById(int id)
	{
		return dbContext.PlaceItems.Find(id);
	}

	public List<PlaceItem> GetAllPlaceItems()
	{
		return dbContext.PlaceItems.ToList();
	}

	public void UpdatePlaceItem(PlaceItem placeItem)
	{
		var existingItem = dbContext.PlaceItems.Find(placeItem.Id);
		if (existingItem != null)
		{
			dbContext.Entry(existingItem).CurrentValues.SetValues(placeItem);
		}
		else
		{
			throw new KeyNotFoundException("PlaceItem not found.");
		}
	}

	public void DeletePlaceItem(int id)
	{
		var placeItem = dbContext.PlaceItems.Find(id);
		if (placeItem != null)
		{
			dbContext.PlaceItems.Remove(placeItem);
		}
		else
		{
			throw new KeyNotFoundException("PlaceItem not found.");
		}
	}
}
