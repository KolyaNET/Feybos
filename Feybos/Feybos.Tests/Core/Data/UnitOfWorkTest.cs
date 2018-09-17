using Moq;
using System;
using System.Data;
using Feybos.Domain.Interfaces.Enums;
using Feybos.Infrastructure.Data.UoW;
using Xunit;

namespace Feybos.Tests.Core.Data
{
	public class UnitOfWorkTest
	{
		protected readonly Mock<IDbTransaction> Transaction;
		protected readonly UnitOfWork UnitOfWork;

		public UnitOfWorkTest()
		{
			Transaction = new Mock<IDbTransaction>();

			UnitOfWork = new UnitOfWork(Transaction.Object);
		}

		public class NewUnitOfWork : UnitOfWorkTest
		{
			[Fact]
			public void Should_have_open_state()
			{
				//Assert
				Assert.Equal(UnitOfWorkState.Open, UnitOfWork.State);
			}
		}

		public class Commit : UnitOfWorkTest
		{
			[Fact]
			public void Should_commit_transaction_and_have_committed_state()
			{
				//Act
				UnitOfWork.Commit();

				//Assert
				Assert.Equal(UnitOfWorkState.Comitted, UnitOfWork.State);
			}

			[Fact]
			public void Should_fail_commit_and_rollback()
			{
				//Arrange
				Transaction
					.Setup(t => t.Commit())
					.Throws(new Exception("fake exception"));

				//Assert
				Assert.Throws<Exception>(() => UnitOfWork.Commit());
			}
		}

		public class Rollback : UnitOfWorkTest
		{
			[Fact]
			public void Should_rollback_transaction_and_have_rolledback_state()
			{
				//Act
				UnitOfWork.Rollback();

				//Assert
				Assert.Equal(UnitOfWorkState.RolledBack, UnitOfWork.State);
			}
		}
	}
}
