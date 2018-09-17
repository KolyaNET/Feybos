using System.Data;
using System.Threading.Tasks;
using Dapper;
using Feybos.Domain.Core.Report;
using Feybos.Domain.Interfaces;
using Feybos.Domain.Interfaces.Repositories.Report;

namespace Feybos.Infrastructure.Data.DapperDataAccess.Repositories
{
	public sealed class ReportCoreDapperRepository : IReportCoreRepository
	{
		private readonly IDbContext _dbContext;

		public ReportCoreDapperRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		private IDbConnection Connection =>
			_dbContext.UnitOfWork.Transaction.Connection;

		private IDbTransaction Transaction =>
			_dbContext.UnitOfWork.Transaction;

		public async Task<ReportCore> GetAsync(string id)
		{
			return await Connection.QuerySingleOrDefaultAsync<ReportCore>(
				"select * from dbo.Product where Id = @id",
				new { id }, transaction: Transaction);
		}
	}
}