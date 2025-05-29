using End2EndTests.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;

namespace End2EndTests.Steps;

[Binding]
public class HealthCheckSteps(TestWebApplicationFactory factory, ScenarioContext scenarioContext) : BaseSteps(factory)
{
	[When(@"a GET request is sent to '(.*)'")]
	public async Task WhenAgetRequestIsSentTo(string uri)
	{
		scenarioContext["response"] = await HttpClient.GetAsync(uri);
	}

	[Then(@"the response status code should be (.*) OK")]
	public void ThenTheResponseStatusCodeShouldBeOk(int p0)
	{
		var response = (HttpResponseMessage)scenarioContext["response"];
		Assert.IsNotNull(response);
		response.EnsureSuccessStatusCode();
	}

	[Then(@"the response body status should be '(.*)'")]
	public async Task ThenTheResponseBodyStatusShouldBe(string healthy)
	{
		var response = (HttpResponseMessage)scenarioContext["response"];
		var content = await response.Content.ReadAsStringAsync();
		Assert.AreEqual(content, "Healthy");
	}
}
