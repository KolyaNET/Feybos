using System.Threading.Tasks;
using Feybos.Domain.Core.Report;

namespace Feybos.Domain.Interfaces.Services.Report
{
	public interface IReportCoreService
	{
		Task<ReportCore> GetAsync(string id);
	}
}