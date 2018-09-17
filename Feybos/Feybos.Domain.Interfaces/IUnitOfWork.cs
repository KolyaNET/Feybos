using System.Data;
using Feybos.Domain.Interfaces.Enums;

namespace Feybos.Domain.Interfaces
{
	public interface IUnitOfWork
	{
		/// <summary>
		/// Represents the current state of the unit of work
		/// </summary>
		UnitOfWorkState State { get; }

		/// <summary>
		/// Represents the current transaction
		/// </summary>
		IDbTransaction Transaction { get; }

		/// <summary>
		/// Commit Transaction
		/// Close Transaction.Connection
		/// Set State to IUnitOfWorkState.Comitted
		/// Dispose Transaction.Connect & Transaction
		/// </summary>
		void Commit();

		/// <summary>
		/// Rollback Transaction
		/// Close Transaction.Connection
		/// Set State to IUnitOfWorkState.RolledBack
		/// Dispose Transaction.Connect & Transaction
		/// </summary>
		void Rollback();
	}
}