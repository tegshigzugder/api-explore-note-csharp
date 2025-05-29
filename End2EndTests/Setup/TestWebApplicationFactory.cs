using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Runtime_Program = ExploreNoteApi.Runtime.Program;

namespace End2EndTests.Setup;

public class TestWebApplicationFactory : WebApplicationFactory<Runtime_Program>
{
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		CreateRequiredConfigFiles(builder);
		var testConfig = new Dictionary<string, string>
		{
			{ "ConnectionStrings:Database", TestDbProvider.Container.GetConnectionString() },
		};
		builder.ConfigureAppConfiguration(configBuilder => configBuilder.AddInMemoryCollection(testConfig));
		builder.ConfigureTestServices(services =>
		{
		});
	}

	private static void CreateRequiredConfigFiles(IWebHostBuilder builder)
	{
		var contentRoot = builder.GetSetting("contentRoot")!;
		var connectionStringFilePath = Path.Combine(contentRoot, "connectionstrings.json");

		CreateFileIfMissing(connectionStringFilePath,
			"""
			{
			    "ConnectionStrings": {
			    }
			}
			""");
	}

	private static void CreateFileIfMissing(string configFile, string content)
	{
		if (!File.Exists(configFile))
		{
			File.WriteAllText(configFile, content);
		}
	}
}
