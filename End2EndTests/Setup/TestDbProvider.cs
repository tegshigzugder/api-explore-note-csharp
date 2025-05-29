using DotNet.Testcontainers.Images;
using Testcontainers.MySql;

namespace End2EndTests.Setup;

internal static class TestDbProvider
{
	public static readonly MySqlContainer Container =
		new MySqlBuilder()
			.WithDatabase("testdb")
			.WithUsername("testdbuser")
			.WithPassword("testdbpass")
			.WithImage("mysql:8.0")
			.WithCleanUp(true)
			.WithImagePullPolicy(PullPolicy.Missing)
			.Build();
}
