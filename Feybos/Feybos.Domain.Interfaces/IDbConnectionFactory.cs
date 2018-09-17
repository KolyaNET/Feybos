using System.Data;

namespace Feybos.Domain.Interfaces
{
	public interface IDbConnectionFactory
	{
		IDbConnection CreateOpenConnection();
	}
}