#nullable disable
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MojeVlastniStranka.Web
{
	public static class HealthCheckExtensions
	{
		public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddHealthChecks()
				  .AddNpgSql(
					  connectionString: configuration.GetConnectionString("DefaultConnection"),
					  healthQuery: "SELECT 1",
					  name: "Postgres DB",
					  failureStatus: HealthStatus.Unhealthy,
					  tags: new[] { "Database" })
				 .AddCheck<RemoteHealthCheck>("Remote endpoints Health Check", failureStatus: HealthStatus.Unhealthy)
				 .AddCheck<MemoryHealthCheck>("Feedback Service Memory Check", failureStatus: HealthStatus.Unhealthy, tags: new[] { "Feedback Service" });

		}
	}
}
