using Feybos.Infrastructure.Data.UoW;
using Moq;
using System.Data;
using Xunit;

namespace Feybos.Tests.Core.Data
{
	public class DbConnectionFactoryTest
	{
		protected readonly Mock<IDbConnection> Connection;
		protected readonly DbConnectionFactory ConnectionFactory;

		public DbConnectionFactoryTest()
		{
			Connection = new Mock<IDbConnection>();
			ConnectionFactory = new DbConnectionFactory(ConnectionFactoryFn);
		}

		public IDbConnection ConnectionFactoryFn()
		{
			var c = Connection.Object;
			c.Open();

			return c;
		}

		public class CreateOpenConnection : DbConnectionFactoryTest
		{
			[Fact]
			public void Should_create_open_connection()
			{
				//Arrange
				Connection
					.SetupGet(c => c.State)
					.Returns(ConnectionState.Open);

				//Act
				var conn = ConnectionFactory.CreateOpenConnection();

				//Assert
				Assert.IsAssignableFrom<IDbConnection>(conn);
				Assert.Equal(ConnectionState.Open, conn.State);
			}
		}
	}
}