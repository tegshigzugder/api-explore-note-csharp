using FernwehApi.Database.Models;

namespace FernwehApi.Repositories;

public interface IPlacesDbRepository
{
	Task Save(List<Place> listPlaces);
}
