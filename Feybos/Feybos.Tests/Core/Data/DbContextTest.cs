using Feybos.Domain.Interfaces.Enums;
using Moq;
using System;
using System.Data;
using Feybos.Domain.Interfaces;
using Xunit;
using Feybos.Infrastructure.Data.UoW;

namespace Feybos.Tests.Core.Data
{
	public class DbContextTest
	{
		protected Mock<IDbConnection> Connection;
		protected DbContext Db;
		protected Mock<IDbConnectionFactory> DbConnectionFactory;
		protected Mock<IDbTransaction> Transaction;

		public DbContextTest()
		{
			Connection = new Mock<IDbConnection>();
			DbConnectionFactory = new Mock<IDbConnectionFactory>();
			Transaction = new Mock<IDbTransaction>();

			Connection
			  .Setup(c => c.BeginTransaction())
			  .Returns(Transaction.Object);

			DbConnectionFactory
			  .Setup(u => u.CreateOpenConnection())
			  .Returns(Connection.Object);

			Db = new DbContext(DbConnectionFactory.Object);
		}

		public class NewDbContext : DbContextTest
		{
			[Fact]
			public void Should_have_closed_state()
			{
				//Assert
				Assert.Equal(DbContextState.Closed, Db.State);
			}
		}

		public class OpenDbContext : DbContextTest
		{
			[Fact]
			public void Should_have_open_state()
			{
				//Arrange
				var uow = Db.UnitOfWork;

				//Assert
				Assert.Equal(DbContextState.Open, Db.State);
			}
		}

		public class Commit : DbContextTest
		{
			[Fact]
			public void Should_commit_unitofwork_and_have_committed_state()
			{
				//Act
				Db.Commit();

				//Assert
				Assert.Equal(DbContextState.Comitted, Db.State);
			}

			[Fact]
			public void Should_fail_commit_and_rollback()
			{
				//Arrange
				Transaction
				  .Setup(t => t.Commit())
				  .Throws(new Exception("fake exception"));

				//Assert
				Assert.Throws<Exception>(() => Db.Commit());
			}
		}

		public class Rollback : DbContextTest
		{
			[Fact]
			public void Should_rollback_unitofwork_and_have_rolledback_state()
			{
				//Act
				Db.Rollback();

				//Assert
				Assert.Equal(DbContextState.RolledBack, Db.State);
			}
		}
	}
}