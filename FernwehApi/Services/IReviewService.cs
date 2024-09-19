using System.Collections.Generic;
using System.Threading.Tasks;
using FernwehApi.Database.Models;
using static FernwehApi.Controllers.ReviewController;

namespace FernwehApi.Services;
public interface IReviewService
{
	void AddReview(int userId, long placeId, PlaceReviewRequestDto placeItemReviewRequestDto);
	Task<List<PlaceDetailsResponseDto>> GetReview(int userId, long placeId);
}
