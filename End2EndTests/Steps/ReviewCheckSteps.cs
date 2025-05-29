using End2EndTests.Setup;
using Reqnroll;

namespace End2EndTests.Steps;

[Binding]
public class ReviewCheckSteps(
TestWebApplicationFactory factory,
	ScenarioContext scenarioContext)
	: BaseSteps(factory)
{
	[Given(@"a user with userId '(.*)' searches for reviews for the place with placeId '(.*)'")]
	public async Task GivenAUserWithUserIdSearchesForReviewsForThePlaceWithPlaceId(string user, string place)
	{

	}
}
