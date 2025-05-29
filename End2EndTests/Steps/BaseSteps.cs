using End2EndTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace End2EndTests.Steps;

[Binding]
public class BaseSteps : IDisposable
{
    protected static HttpClient HttpClient { get; set; } = null!;
    private readonly TestWebApplicationFactory _factory;
    private readonly IServiceScope _scope;

    public BaseSteps(TestWebApplicationFactory factory)
    {
        _factory = factory;
        HttpClient = _factory.CreateClient();
        _scope = _factory.Services.CreateScope();
    }

    public void Dispose()
    {
        _factory.Dispose();
        _scope.Dispose();
        HttpClient.Dispose();
    }
}
