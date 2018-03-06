using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using MShop.DataLayer.NHibernate.Mappings.Articles;
using MShop.DataLayer.NHibernate.Mappings.Forums;
using MShop.DataLayer.NHibernate.Mappings.Newsletters;
using MShop.DataLayer.NHibernate.Mappings.Polls;
using MShop.DataLayer.NHibernate.Mappings.Store;

namespace MShop.DataLayer.NHibernate
{
	public class NHUnitOfWork : IUnitOfWork
	{
		private static string _connectionString;
		private static ISessionFactory _sessionFactory;
		private ITransaction _transaction;

		public ISession Session { get; private set; }
		private static ISessionFactory SessionFactory
		{
			get
			{
				if (_sessionFactory == null)
				{
					_sessionFactory = Fluently.Configure()
											   .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connectionString))
											   .Mappings(m => m.FluentMappings.Add<CategoryMapping>())
											   .Mappings(m => m.FluentMappings.Add<ArticleMapping>())
											   .Mappings(m => m.FluentMappings.Add<CommentMapping>())
											   .Mappings(m => m.FluentMappings.Add<ForumMapping>())
											   .Mappings(m => m.FluentMappings.Add<PostMapping>())
											   .Mappings(m => m.FluentMappings.Add<NewsletterMapping>())
											   .Mappings(m => m.FluentMappings.Add<PollMapping>())
											   .Mappings(m => m.FluentMappings.Add<PollOptionMapping>())
											   .Mappings(m => m.FluentMappings.Add<DepartmentMapping>())
											   .Mappings(m => m.FluentMappings.Add<OrderItemMapping>())
											   .Mappings(m => m.FluentMappings.Add<OrderMapping>())
											   .Mappings(m => m.FluentMappings.Add<OrderStatusMapping>())
											   .Mappings(m => m.FluentMappings.Add<ProductMapping>())
											   .Mappings(m => m.FluentMappings.Add<ShippingMethodMapping>())
											   .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
											   .BuildSessionFactory();
				}
				return _sessionFactory;
			}
		}
		static NHUnitOfWork()
		{
			// Initialise singleton instance of ISessionFactory, static constructors are only executed once during the
			// application lifetime - the first time the UnitOfWork class is used
			//_sessionFactory = Fluently.Configure()
			//	.Database(MsSqlConfiguration.MsSql2012.ConnectionString(x => x.FromConnectionStringWithKey("DefaultConnection")))
			//	.Mappings(x => x.AutoMappings.Add(
			//		AutoMap.AssemblyOf<Article>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<ArticleMapping>()))

			//	.ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
			//	.BuildSessionFactory();

			//_sessionFactory = Fluently.Configure()
			//								.Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
			//								.Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ArticleMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<CommentMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ForumMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<PostMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<NewsletterMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<PollMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<PollOptionMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<DepartmentMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderItemMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderStatusMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMapping>())
			//								//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ShippingMethodMapping>())
			//								.ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
			//								.BuildSessionFactory();
		}

		public NHUnitOfWork(string conString)
		{
			_connectionString = conString;
		}

		public void BeginTransaction()
		{
			Session = SessionFactory.OpenSession();
			_transaction = Session.BeginTransaction();
		}

		public void Commit()
		{
			try
			{
				// commit transaction if there is one active
				if (_transaction != null && _transaction.IsActive)
					_transaction.Commit();
			}
			catch
			{
				// rollback if there was an exception
				if (_transaction != null && _transaction.IsActive)
					_transaction.Rollback();

				throw;
			}
			finally
			{
				Session.Dispose();
			}
		}

		public void Rollback()
		{
			try
			{
				if (_transaction != null && _transaction.IsActive)
					_transaction.Rollback();
			}
			finally
			{
				Session.Dispose();
			}
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					Session.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
