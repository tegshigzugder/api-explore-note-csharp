using System.Collections.Generic;
using System.Threading.Tasks;
using ExploreNoteApi.Models;

namespace ExploreNoteApi.Services;

public interface IReviewService
{
	void AddReview(int userId, long placeId, PlaceReviewRequestDto placeItemReviewRequestDto);
	Task<List<PlaceDetailsResponseDto>> GetReview(int userId, long placeId);
	Task<List<PlaceDetailsResponseDto>> GetAllReviews();
}
