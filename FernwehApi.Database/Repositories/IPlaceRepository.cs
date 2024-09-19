using FernwehApi.Database.Models;

namespace FernwehApi.Database.Repositories;


/// <summary>
/// Interface for Place repository to handle CRUD operations.
/// </summary>
public interface IPlaceRepository
{
    /// <summary>
    /// Gets a place by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the place.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the place if found; otherwise, null.</returns>
    Task<Place?> GetPlaceById(long NodeId);

    /// <summary>
    /// Gets all places.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of all places.</returns>
    Task<List<Place>> GetAllPlaces();

    /// <summary>
    /// Adds a new place.
    /// </summary>
    /// <param name="place">The place to add.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddPlace(Place place);

    /// <summary>
    /// Updates an existing place.
    /// </summary>
    /// <param name="place">The place to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdatePlace(Place place);

    /// <summary>
    /// Deletes a place by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the place to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeletePlace(long NodeId);
}