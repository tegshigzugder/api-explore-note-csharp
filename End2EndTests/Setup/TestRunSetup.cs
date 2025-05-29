using MySql.Data.MySqlClient;
using Reqnroll;

namespace End2EndTests.Setup;

[Binding]
public static class TestRunSetup
{
	[BeforeTestRun]
	public static async Task BeforeTestRun()
	{
		await TestDbProvider.Container.StartAsync();
		await using var testQuery = new MySqlConnection(TestDbProvider.Container.GetConnectionString());
		await ExecuteTestQuery(testQuery);
	}

	[AfterTestRun]
	public static async Task AfterTestRun()
	{
		await TestDbProvider.Container.StopAsync();
	}

	private static async Task ExecuteTestQuery(MySqlConnection connection)
	{
		var assembly = typeof(TestRunSetup).Assembly;
		const string resourceName =
			"ExploreNoteApi.End2EndTests.Assets.TestQuery.sql";

		await using var stream = assembly.GetManifestResourceStream(resourceName);
		if (stream == null)
		{
			throw new InvalidOperationException($"Resource '{resourceName}' not found.");
		}

		using var reader = new StreamReader(stream);
		var testQuery = await reader.ReadToEndAsync();

		// await connection.ExecuteAsync(testQuery);
	}
}
