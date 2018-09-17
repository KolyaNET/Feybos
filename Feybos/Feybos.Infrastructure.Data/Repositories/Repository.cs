using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Feybos.Domain.Interfaces;

namespace Feybos.Infrastructure.Data.Repositories
{
	public abstract class Repository<TEntity> where TEntity : class
	{
		private readonly IDbContext _dbContext;

		public Repository(IDbContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		}

		private IDbConnection Db =>
		  _dbContext.UnitOfWork.Transaction.Connection;

		private IDbTransaction Transaction =>
		  _dbContext.UnitOfWork.Transaction;

		/// <summary>
		/// Execute
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="param"></param>
		/// <param name="commandTimeout"></param>
		/// <param name="commandType"></param>
		/// <returns>Number of rows affected</returns>
		protected async Task<int> Execute(string sql, object param = null,
			int commandTimeout = 30, CommandType commandType = CommandType.Text)
		{
			return await Db.ExecuteAsync(sql, param, Transaction,
				commandTimeout: commandTimeout, commandType: commandType);
		}

		/// <summary>
		/// Execute scalar
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sql"></param>
		/// <param name="param"></param>
		/// <param name="commandTimeout"></param>
		/// <param name="commandType"></param>
		/// <returns></returns>
		protected async Task<T> ExecuteScalar<T>(string sql, object param = null,
			int commandTimeout = 30, CommandType commandType = CommandType.Text)
		{
			return await Db.ExecuteScalarAsync<T>(sql, param, Transaction,
				commandTimeout: commandTimeout, commandType: commandType);
		}

		/// <summary>
		/// First or default
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="param"></param>
		/// <param name="commandTimeout"></param>
		/// <param name="commandType"></param>
		/// <returns>Record or null</returns>
		protected async Task<TEntity> QueryFirstOrDefault(string sql, object param = null,
			int commandTimeout = 30, CommandType commandType = CommandType.Text)
		{
			return await Db.QueryFirstOrDefaultAsync<TEntity>(sql, param, Transaction,
				commandTimeout: commandTimeout, commandType: commandType);
		}

		/// <summary>
		/// Single or default
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="param"></param>
		/// <param name="commandTimeout"></param>
		/// <param name="commandType"></param>
		/// <returns>Record or throws exception</returns>
		protected async Task<TEntity> QuerySingleOrDefault(string sql, object param = null,
			int commandTimeout = 30, CommandType commandType = CommandType.Text)
		{
			return await Db.QuerySingleOrDefaultAsync<TEntity>(sql, param, Transaction,
				commandTimeout: commandTimeout, commandType: commandType);
		}

		/// <summary>
		/// Query
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="param"></param>
		/// <param name="commandTimeout"></param>
		/// <param name="commandType"></param>
		/// <returns></returns>
		protected async Task<IEnumerable<TEntity>> Query(string sql, object param = null,
			int commandTimeout = 30, CommandType commandType = CommandType.Text)
		{
			return await Db.QueryAsync<TEntity>(sql, param, Transaction,
				commandTimeout: commandTimeout, commandType: commandType);
		}

		/// <summary>
		/// Multimap 2
		/// </summary>
		/// <typeparam name="TSecond"></typeparam>
		/// <param name="sql"></param>
		/// <param name="map"></param>
		/// <param name="param"></param>
		/// <param name="commandTimeout"></param>
		/// <param name="commandType"></param>
		/// <param name="splitOn"></param>
		/// <returns></returns>
		protected async Task<IEnumerable<TEntity>> Query<TSecond>(string sql,
			Func<TEntity, TSecond, TEntity> map, object param = null,
			int commandTimeout = 30, CommandType commandType = CommandType.Text, string splitOn = "Id")
		{
			return await Db.QueryAsync(sql, map, param, Transaction,
				commandTimeout: commandTimeout, commandType: commandType, splitOn: splitOn);
		}

		/// <summary>
		/// Multimap 3
		/// </summary>
		/// <typeparam name="TSecond"></typeparam>
		/// <typeparam name="TThird"></typeparam>
		/// <param name="sql"></param>
		/// <param name="map"></param>
		/// <param name="param"></param>
		/// <param name="commandTimeout"></param>
		/// <param name="commandType"></param>
		/// <param name="splitOn"></param>
		/// <returns></returns>
		protected async Task<IEnumerable<TEntity>> Query<TSecond, TThird>(string sql,
			Func<TEntity, TSecond, TThird, TEntity> map, object param = null,
			int commandTimeout = 30, CommandType commandType = CommandType.Text, string splitOn = "Id")
		{
			return await Db.QueryAsync(sql, map, param, Transaction,
				commandTimeout: commandTimeout, commandType: commandType, splitOn: splitOn);
		}

		/// <summary>
		/// Multimap 4
		/// </summary>
		/// <typeparam name="TSecond"></typeparam>
		/// <typeparam name="TThird"></typeparam>
		/// <typeparam name="TFourth"></typeparam>
		/// <param name="sql"></param>
		/// <param name="map"></param>
		/// <param name="param"></param>
		/// <param name="commandTimeout"></param>
		/// <param name="commandType"></param>
		/// <param name="splitOn"></param>
		/// <returns></returns>
		protected async Task<IEnumerable<TEntity>> Query<TSecond, TThird, TFourth>(string sql,
			Func<TEntity, TSecond, TThird, TFourth, TEntity> map, object param = null,
			int commandTimeout = 30, CommandType commandType = CommandType.Text, string splitOn = "Id")
		{
			return await Db.QueryAsync(sql, map, param, Transaction,
				commandTimeout: commandTimeout, commandType: commandType, splitOn: splitOn);
		}

		/// <summary>
		/// Multimap 5
		/// </summary>
		/// <typeparam name="TSecond"></typeparam>
		/// <typeparam name="TThird"></typeparam>
		/// <typeparam name="TFourth"></typeparam>
		/// <typeparam name="TFifth"></typeparam>
		/// <param name="sql"></param>
		/// <param name="map"></param>
		/// <param name="param"></param>
		/// <param name="commandTimeout"></param>
		/// <param name="commandType"></param>
		/// <param name="splitOn"></param>
		/// <returns></returns>
		protected async Task<IEnumerable<TEntity>> Query<TSecond, TThird, TFourth, TFifth>(string sql,
			Func<TEntity, TSecond, TThird, TFourth, TFifth, TEntity> map, object param = null,
			int commandTimeout = 30, CommandType commandType = CommandType.Text, string splitOn = "Id")
		{
			return await Db.QueryAsync(sql, map, param, Transaction,
				commandTimeout: commandTimeout, commandType: commandType, splitOn: splitOn);
		}

		/// <summary>
		/// Multimap 6
		/// </summary>
		/// <typeparam name="TSecond"></typeparam>
		/// <typeparam name="TThird"></typeparam>
		/// <typeparam name="TFourth"></typeparam>
		/// <typeparam name="TFifth"></typeparam>
		/// <typeparam name="TSixth"></typeparam>
		/// <param name="sql"></param>
		/// <param name="map"></param>
		/// <param name="param"></param>
		/// <param name="commandTimeout"></param>
		/// <param name="commandType"></param>
		/// <param name="splitOn"></param>
		/// <returns></returns>
		protected async Task<IEnumerable<TEntity>> Query<TSecond, TThird, TFourth, TFifth, TSixth>(string sql,
			Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, object param = null,
			int commandTimeout = 30, CommandType commandType = CommandType.Text, string splitOn = "Id")
		{
			return await Db.QueryAsync(sql, map, param, Transaction,
				commandTimeout: commandTimeout, commandType: commandType, splitOn: splitOn);
		}

		/// <summary>
		/// Multimap 7
		/// </summary>
		/// <typeparam name="TSecond"></typeparam>
		/// <typeparam name="TThird"></typeparam>
		/// <typeparam name="TFourth"></typeparam>
		/// <typeparam name="TFifth"></typeparam>
		/// <typeparam name="TSixth"></typeparam>
		/// <typeparam name="TSeventh"></typeparam>
		/// <param name="sql"></param>
		/// <param name="map"></param>
		/// <param name="param"></param>
		/// <param name="commandTimeout"></param>
		/// <param name="commandType"></param>
		/// <param name="splitOn"></param>
		/// <returns></returns>
		protected async Task<IEnumerable<TEntity>> Query<TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string sql,
			Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, object param = null,
			int commandTimeout = 30, CommandType commandType = CommandType.Text, string splitOn = "Id")
		{
			return await Db.QueryAsync(sql, map, param, Transaction,
				commandTimeout: commandTimeout, commandType: commandType, splitOn: splitOn);
		}
	}
}