using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Unik.Crosscut.TransactionHandling.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _db;
    private IDbContextTransaction _transcation;

    public UnitOfWork(DbContext db)
    {
        _db = db;
    }

    void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
    {
        _transcation = _db.Database.CurrentTransaction ?? _db.Database.BeginTransaction(isolationLevel);
    }

    void IUnitOfWork.Commit()
    {
        _transcation.Commit();
        _transcation.Dispose();
    }

    void IUnitOfWork.Rollback()
    {
        _transcation.Rollback();
        _transcation.Dispose();
    }
}