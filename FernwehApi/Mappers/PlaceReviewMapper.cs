using FernwehApi.Database.Models;

namespace FernwehApi.Mappers;

public static class PlaceReviewMapper
{
	public static PlaceReview ToPlaceReview(int userId, int placeId, PlaceReviewRequestDto dto)
	{
		return new PlaceReview
		{
			Rating = dto.Rating,
			Comment = dto.Comment
		};
	}
}
