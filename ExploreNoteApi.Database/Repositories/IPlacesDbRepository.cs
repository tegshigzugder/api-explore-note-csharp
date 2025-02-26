using ExploreNoteApi.Database.Models;

namespace ExploreNoteApi.Database.Repositories;

public interface IPlacesDbRepository
{
	Task Save(List<Place> listPlaces);
}
