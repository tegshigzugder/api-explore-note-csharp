SELECT *
FROM Users
    INNER JOIN PlaceReviews ON Users.ID = PlaceReviews.UserID
    INNER JOIN PlaceItems ON PlaceReviews.PlaceID = PlaceItems.PlaceID