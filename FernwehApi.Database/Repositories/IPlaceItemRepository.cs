using FernwehApi.Database.Models;

namespace FernwehApi.Database.Repositories;

public interface IPlaceItemRepository
{
    List<PlaceItem> GetAllPlaceItems();
    PlaceItem GetPlaceItemById(int id);
    Task AddPlaceItemAsync(PlaceItem placeItem);
    void UpdatePlaceItem(PlaceItem placeItem);
    void DeletePlaceItem(int id);
}