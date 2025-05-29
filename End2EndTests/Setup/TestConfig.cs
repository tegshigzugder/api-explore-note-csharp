using ExploreNoteApi.Runtime;
using Microsoft.AspNetCore.Builder;

namespace End2EndTests.Setup;

public class TestConfig : RuntimeConfig
{
	public override void ConfigureRuntimeRequiredBuilder(WebApplicationBuilder builder)
	{
	}

	public override void ConfigureRuntimeApplication(WebApplication application, WebApplicationBuilder builder)
	{
	}
}
