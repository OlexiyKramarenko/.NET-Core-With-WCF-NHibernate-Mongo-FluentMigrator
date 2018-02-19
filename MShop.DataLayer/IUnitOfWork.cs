using System;

namespace MShop.DataLayer
{
    public interface IUnitOfWork : IDisposable
    {
		void BeginTransaction();
		void Commit();
        void Rollback();
    }
}
