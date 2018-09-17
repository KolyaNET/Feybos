using System;
using System.Data;
using Feybos.Domain.Interfaces;
using Feybos.Domain.Interfaces.Enums;

namespace Feybos.Infrastructure.Data.UoW
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork(IDbTransaction transaction)
		{
			State = UnitOfWorkState.Open;
			Transaction = transaction;
		}

		public UnitOfWorkState State { get; private set; }

		public IDbTransaction Transaction { get; }

		public void Commit()
		{
			try
			{
				Transaction.Commit();
				State = UnitOfWorkState.Comitted;
			}
			catch (Exception)
			{
				Transaction.Rollback();
				throw;
			}
		}

		public void Rollback()
		{
			Transaction.Rollback();
			State = UnitOfWorkState.RolledBack;
		}
	}
}