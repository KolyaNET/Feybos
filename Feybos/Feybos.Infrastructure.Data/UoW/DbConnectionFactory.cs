using System;
using System.Data;
using Feybos.Domain.Interfaces;

namespace Feybos.Infrastructure.Data.UoW
{
	public sealed class DbConnectionFactory : IDbConnectionFactory
	{
		private readonly Func<IDbConnection> _connectionFactoryFn;

		/// <summary>
		/// Responsible for instantiating new IDbConnection's
		/// </summary>
		/// <param name="connectionFactory">Should return open IDbConnection instance</param>
		public DbConnectionFactory(Func<IDbConnection> connectionFactory)
		{
			_connectionFactoryFn = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
		}

		public IDbConnection CreateOpenConnection()
		{
			return _connectionFactoryFn();
		}
	}
}