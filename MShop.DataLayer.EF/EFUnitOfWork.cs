using System;

namespace MShop.DataLayer.EF
{
	public class EfUnitOfWork : IUnitOfWork
	{
		private readonly DataBaseContext _context;
		
		public DataBaseContext Context { get { return _context; } }

		public EfUnitOfWork(DataBaseContext context)
		{
			_context = context;
		}

		public void Commit()
		{
			int result = this.Context.SaveChanges();
		}

		public void BeginTransaction()
		{
			throw new NotImplementedException();
		}
		public void Rollback()
		{
			throw new NotImplementedException();
		}
		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
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
