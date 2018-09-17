using System.Threading.Tasks;
using Feybos.Domain.Core.Report;
using Feybos.Domain.Interfaces;
using Feybos.Domain.Interfaces.Repositories.Report;
using Feybos.Domain.Interfaces.Services.Report;

namespace Feybos.Infrastructure.Data.Services.Report
{
	public sealed class ReportCoreService : IReportCoreService
	{
		private readonly IDbContext _dbContext;
		private readonly IReportCoreRepository _reportCoreRepository;

		public ReportCoreService(
			IDbContext dbContext,
			IReportCoreRepository productRepository)
		{
			_dbContext = dbContext;
			_reportCoreRepository = productRepository;
		}

		public async Task<ReportCore> GetAsync(string id)
		{
			var product = await _reportCoreRepository.GetAsync(id);
			_dbContext.Commit();

			return product;
		}
	}
}