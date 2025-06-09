using System.Net;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using DotNet.Testcontainers.Networks;

public sealed class UnitTest1 : IAsyncLifetime, IDisposable
{
    private const ushort HttpPort = 80;
    private readonly CancellationTokenSource _cts = new(TimeSpan.FromMinutes(1));
    private readonly IDockerNetwork _network;
    private readonly IDockerContainer _dbContainer;
    private readonly IDockerContainer _appContainer;

    public UnitTest1()
    {
        _network = new TestcontainersNetworkBuilder()
            .WithName(Guid.NewGuid().ToString("D"))
            .Build();

        _dbContainer = new TestcontainersBuilder<TestcontainersContainer>()
            .WithImage("postgres")
            .WithNetwork(_network)
            .WithNetworkAliases("db")
            .WithVolumeMount("postgres-data", "/var/lib/postgresql/data")
            .Build();

        _appContainer = new TestcontainersBuilder<TestcontainersContainer>()
            .WithImage("dotnet-docker")
            .WithNetwork(_network)
            .WithPortBinding(HttpPort, true)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(HttpPort))
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _network.CreateAsync(_cts.Token)
            .ConfigureAwait(false);

        await _dbContainer.StartAsync(_cts.Token)
            .ConfigureAwait(false);

        await _appContainer.StartAsync(_cts.Token)
            .ConfigureAwait(false);
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _cts.Dispose();
    }

    [Fact]
    public async Task Test1()
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new UriBuilder("http", _appContainer.Hostname, _appContainer.GetMappedPublicPort(HttpPort)).Uri;

        var httpResponseMessage = await httpClient.GetAsync(string.Empty)
            .ConfigureAwait(false);

        var body = await httpResponseMessage.Content.ReadAsStringAsync()
            .ConfigureAwait(false);

        Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
        Assert.Contains("Welcome", body);
    }
}