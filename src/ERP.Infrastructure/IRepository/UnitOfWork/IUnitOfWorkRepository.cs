using ERP.Infrastructure.IRepository.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.IRepository.UnitOfWork;

public interface IUnitOfWorkRepository : IDisposable
{
    ICompanyRepository CompanyRepository { get; }

    Task BeginTransaction();
    Task<int> SaveChangesAsync();
    Task CommitAsync();
    Task SaveAndCommitAsync();
    Task RollbackAsync();
}
