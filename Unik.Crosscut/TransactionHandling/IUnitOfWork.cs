using System.Data;

namespace Unik.Crosscut.TransactionHandling;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void BeginTransaction(IsolationLevel isolationLevel);
}