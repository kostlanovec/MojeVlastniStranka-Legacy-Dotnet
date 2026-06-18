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

			services.AddHealthChecksUI(opt =>
			{
				opt.SetEvaluationTimeInSeconds(100);
				opt.MaximumHistoryEntriesPerEndpoint(60);
				opt.SetApiMaxActiveRequests(1);

				// ABSOLUTNÍ adresa na vlastní health endpoint:
				var baseUrl = configuration["SELF_BASE_URL"] ?? "http://127.0.0.1:8080";
				opt.AddHealthCheckEndpoint("self", $"{baseUrl}/api/health");
			})
			.AddInMemoryStorage();
		}
	}
}
