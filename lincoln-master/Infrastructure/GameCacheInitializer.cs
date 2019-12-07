using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lincoln.Infrastructure
{
  public class GameCacheInitializer : IHostedService {
    public readonly IServiceProvider _serviceProvider;

    public GameCacheInitializer(IServiceProvider serviceProvider) {
      this._serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
      using (var scope = this._serviceProvider.CreateScope()) {
        var gameCache = scope.ServiceProvider.GetRequiredService<GameCache>();
        await gameCache.Initialize();
      }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      return Task.CompletedTask;
    }
  }
}