using System.Threading.Tasks;
using Feybos.Domain.Core.Report;

namespace Feybos.Domain.Interfaces.Repositories.Report
{
	public interface IReportCoreRepository
	{
		Task<ReportCore> GetAsync(string id);
	}
}