using Microsoft.EntityFrameworkCore;
using FernwehApi.Database.Models;

namespace FernwehApi.Database.Repositories;

/// <inheritdoc />
public class PlaceRepository : IPlaceRepository
{
    private readonly FernwehDbContext _dbContext;

    public PlaceRepository(FernwehDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<List<Place>> GetAllPlaces()
    {
        return await _dbContext.Places
            .Include(p => p.PlaceReviews)
            .Include(p => p.PlaceItems)
            .ThenInclude(pl => pl.PlaceItemReviews)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Place?> GetPlaceById(long nodeId)
    {
        return await _dbContext.Places.FirstOrDefaultAsync(p => p.NodeId == nodeId);
    }

    /// <inheritdoc />
    public async Task AddPlace(Place place)
    {
        await _dbContext.Places.AddAsync(place);
        await _dbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdatePlace(Place place)
    {
        _dbContext.Places.Update(place);
        await _dbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeletePlace(long NodeId)
    {
        var place = await _dbContext.Places.FirstOrDefaultAsync(p => p.NodeId == NodeId);
        if (place != null)
        {
            _dbContext.Places.Remove(place);
        }
        await _dbContext.SaveChangesAsync();
    }
}