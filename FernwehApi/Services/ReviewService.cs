using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FernwehApi.Database.Models;
using FernwehApi.Database.Repositories;
using static FernwehApi.Controllers.ReviewController;

namespace FernwehApi.Services;

public class ReviewService : IReviewService
{
	private readonly IPlaceRepository _placeRepository;
	private readonly IPlaceItemRepository _placeItemRepository;

	public ReviewService(IPlaceRepository placeRepository)
	{
		_placeRepository = placeRepository;
	}

	public async void AddReview(int userId, long placeId, PlaceReviewRequestDto placeReviewRequestDto)
	{
		// user does exist
		var placeDb = await _placeRepository.GetPlaceById(placeId);

		// if place doesnt exist create it
		if (placeDb == null)
		{
			// create place
			var place = new Place
			{
				NodeId = placeId,
				Location = placeReviewRequestDto.Location,
				Name = placeReviewRequestDto.Name,
				PlaceReviews = new List<PlaceReview>
				{
					new PlaceReview
					{
						Rating = placeReviewRequestDto.Rating,
						Comment = placeReviewRequestDto.Comment,
					}
				},
				PlaceItems = placeReviewRequestDto.PlaceItemReviews.Select(x => new PlaceItem
				{
					Name = x.PlaceItemName,
					Price = x.PlaceItemPrice,
					PlaceItemReviews = new List<PlaceItemReview>
					{
						new PlaceItemReview
						{
							Rating = x.PlaceItemRating,
							Comment = x.PlaceItemComment,
						}
					}
				}).ToList()
			};
			await _placeRepository.AddPlace(place);
		}
		else
		{
			// if item doesnt exist create it
			// TODO: if place exists and items and reviews
			placeDb.PlaceReviews = new List<PlaceReview>
				{
					new PlaceReview
					{
						Rating = placeReviewRequestDto.Rating,
						Comment = placeReviewRequestDto.Comment,
					}
				};

			placeDb.PlaceItems = placeReviewRequestDto.PlaceItemReviews.Select(x => new PlaceItem
			{
				Name = x.PlaceItemName,
				Price = x.PlaceItemPrice,
				PlaceItemReviews = new List<PlaceItemReview>
			{
				new PlaceItemReview
				{
					Rating = x.PlaceItemRating,
					Comment = x.PlaceItemComment,
				}
			}
			}).ToList();

			await _placeRepository.UpdatePlace(placeDb);
		}

		// var placeDb = await _placeRepository.GetPlaceById(placeId);

		// foreach (var item in placeReviewRequestDto.PlaceItemReviews)
		// {
		//     // create item
		//     var placeItem = new PlaceItem
		//     {
		//         Name = item.PlaceItemName,
		//         Price = item.PlaceItemPrice,
		//         PlaceId = placeId,
		//         Place = placeDb
		//     };
		//     await _placeItemRepository.AddPlaceItemAsync(placeItem);
		// }

		// TODO: map PlaceReviewRequestDto to Review

		// _reviewRepository.Add(review);
	}

	public async Task<List<PlaceDetailsResponseDto>> GetReview(int userId, long placeId)
	{
		var places = await _placeRepository.GetAllPlaces();
		var results = PlaceDetailsResponseDto.ConvertToPlaceDetailsResponseDto(places);
		return results;
	}
}
