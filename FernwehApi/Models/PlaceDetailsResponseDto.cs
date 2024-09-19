using System.Collections.Generic;
using System.Linq;
using FernwehApi.Database.Models;

public class PlaceDetailsResponseDto
{
    public long NodeId { get; set; }
    public string PlaceName { get; set; }
    public string Location { get; set; }
    public List<PlaceReviewDto> Reviews { get; set; }
    public List<PlaceItemDto> PlaceItems { get; set; }
    public static List<PlaceDetailsResponseDto> ConvertToPlaceDetailsResponseDto(List<Place> elements)
    {
        var responseList = new List<PlaceDetailsResponseDto>();
        foreach (var element in elements)
        {
            var response = new PlaceDetailsResponseDto
            {
                NodeId = element.NodeId,
                PlaceName = element.Name,
                Location = element.Location,
                Reviews = ConvertToReviewDtoList(element.PlaceReviews.ToList()),
                PlaceItems = ConvertToPlaceItemDtoList(element.PlaceItems.ToList())
            };
            responseList.Add(response);
        }
        return responseList;
    }

    private static List<PlaceItemDto> ConvertToPlaceItemDtoList(ICollection<PlaceItem> placeItems)
    {
        var dtoList = new List<PlaceItemDto>();
        foreach (var placeItem in placeItems)
        {
            var dto = new PlaceItemDto
            {
                PlaceItemId = placeItem.Id,
                PlaceItemName = placeItem.Name,
                PlaceItemPrice = placeItem.Price,
                PlaceItemReviews = ConvertToPlaceItemReviewDtoList(placeItem.PlaceItemReviews.ToList())
            };
            dtoList.Add(dto);
        }
        return dtoList;
    }

    private static List<PlaceReviewDto> ConvertToReviewDtoList(List<PlaceReview> reviews)
    {
        var dtoList = new List<PlaceReviewDto>();
        foreach (var review in reviews)
        {
            var dto = new PlaceReviewDto
            {
                ReviewId = review.Id,
                Rating = review.Rating,
                Comment = review.Comment
            };
            dtoList.Add(dto);
        }
        return dtoList;
    }

    private static List<PlaceItemReviewDto> ConvertToPlaceItemReviewDtoList(List<PlaceItemReview> placeItemReviews)
    {
        var dtoList = new List<PlaceItemReviewDto>();
        foreach (var review in placeItemReviews)
        {
            var dto = new PlaceItemReviewDto
            {
                PlaceItemReviewId = review.Id,
                Rating = review.Rating,
                Comment = review.Comment
            };
            dtoList.Add(dto);
        }
        return dtoList;
    }
}

public class PlaceReviewDto
{
    public int ReviewId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}

public class PlaceItemDto
{
    public int PlaceItemId { get; set; }
    public string PlaceItemName { get; set; }
    public decimal PlaceItemPrice { get; set; }
    public List<PlaceItemReviewDto> PlaceItemReviews { get; set; }
}

public class PlaceItemReviewDto
{
    public int PlaceItemReviewId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}