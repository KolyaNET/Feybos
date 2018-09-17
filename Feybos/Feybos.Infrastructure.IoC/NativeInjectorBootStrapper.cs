using Feybos.Domain.Interfaces;
using Feybos.Infrastructure.Data.UoW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using Feybos.Domain.Interfaces.Repositories.Report;
using Feybos.Domain.Interfaces.Services.Report;
using Feybos.Infrastructure.Data.DapperDataAccess.Repositories;
using Feybos.Infrastructure.Data.Services.Report;

namespace Feybos.Infrastructure.IoC
{
	public class NativeInjectorBootStrapper
	{
		public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
		{
			// ASP.NET HttpContext dependency
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			/*// Domain Bus (Mediator)
			services.AddScoped<IMediatorHandler, InMemoryBus>();

			// ASP.NET Authorization Polices
			services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

			// Application
			services.AddScoped<ICustomerAppService, CustomerAppService>();

			// Domain - Events
			services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
			services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
			services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
			services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

			// Domain - Commands
			services.AddScoped<IRequestHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
			services.AddScoped<IRequestHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
			services.AddScoped<IRequestHandler<RemoveCustomerCommand>, CustomerCommandHandler>();*/

			// Infra - Data
			services.AddTransient<IDbConnectionFactory>(options =>
			{
				var builder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"));

				return new DbConnectionFactory(() =>
				{
					var conn = new SqlConnection(builder.ConnectionString);

					conn.Open();
					return conn;
				});
			});
			services.AddScoped<IDbContext, DbContext>();

			services.AddScoped<IReportCoreRepository, ReportCoreDapperRepository>();
			services.AddScoped<IReportCoreService, ReportCoreService>();

			/*// Infra - Data EventSourcing
			services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
			services.AddScoped<IEventStore, SqlEventStore>();
			services.AddScoped<EventStoreSQLContext>();

			// Infra - Identity Services
			services.AddTransient<IEmailSender, AuthEmailMessageSender>();
			services.AddTransient<ISmsSender, AuthSMSMessageSender>();

			// Infra - Identity
			services.AddScoped<IUser, AspNetUser>();*/
		}
	}
}
