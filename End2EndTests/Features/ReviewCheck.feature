Feature: ReviewCheck
Verifies that the application's review check endpoint is operational.

	Scenario Outline: User loads reviews for a specific place
		Given a user with userId '<UserId>' searches for reviews for the place with placeId '<PlaceId>'
		When a GET request is sent to '/reviews/<UserId>/<PlaceId>'
		Then the response status code should be 200 OK

		Examples:
		  | UserId | PlaceId |
		  | 1      | 12345   |
