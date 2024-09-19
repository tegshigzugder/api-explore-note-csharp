using FernwehApi.Database.Models;

namespace FernwehApi.Database.Repositories;

public class PlaceItemRepository : IPlaceItemRepository
{
    private readonly FernwehDbContext _dbContext;

    public PlaceItemRepository(FernwehDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddPlaceItemAsync(PlaceItem item)
    {
        await _dbContext.PlaceItems.AddAsync(item);
        await _dbContext.SaveChangesAsync();
    }

    public async void RemovePlaceItem(PlaceItem item)
    {
        _dbContext.PlaceItems.Remove(item);
        await _dbContext.SaveChangesAsync();
    }

    public PlaceItem GetPlaceItemById(int id)
    {
        return _dbContext.PlaceItems.Find(id);
    }

    public List<PlaceItem> GetAllPlaceItems()
    {
        return _dbContext.PlaceItems.ToList();
    }

    public void UpdatePlaceItem(PlaceItem placeItem)
    {
        var existingItem = _dbContext.PlaceItems.Find(placeItem.Id);
        if (existingItem != null)
        {
            _dbContext.Entry(existingItem).CurrentValues.SetValues(placeItem);
        }
        else
        {
            throw new KeyNotFoundException("PlaceItem not found.");
        }
    }

    public void DeletePlaceItem(int id)
    {
        var placeItem = _dbContext.PlaceItems.Find(id);
        if (placeItem != null)
        {
            _dbContext.PlaceItems.Remove(placeItem);
        }
        else
        {
            throw new KeyNotFoundException("PlaceItem not found.");
        }
    }
}