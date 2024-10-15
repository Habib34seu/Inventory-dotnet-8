using ERP.Infrastructure.DataContext;
using ERP.Infrastructure.IRepository.Company;
using ERP.Infrastructure.IRepository.UnitOfWork;
using ERP.Infrastructure.Repository.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace ERP.Infrastructure.Repository.UnitOfWork;

public class UnitOfWorkRepository: IUnitOfWorkRepository
{
    private readonly ApplicationDbContext _context;
    private readonly AppDapperContext _dapperContext;
    private IDbContextTransaction _transaction;


    private readonly ICompanyRepository _iCompanyRepository;


    public UnitOfWorkRepository(ApplicationDbContext context, AppDapperContext dapperContext)
    {
        _context = context;
        _dapperContext = dapperContext;
        _transaction = _context.Database.BeginTransaction();
    }
    public ICompanyRepository CompanyRepository => _iCompanyRepository ?? new CompanyRepository(_context);

    public async Task BeginTransaction()
    {
        _transaction = await Task.Run(() => _context.Database.BeginTransactionAsync());
    }

    public async Task<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Error saving changes. See inner exception for details.", ex);
        }
    }

    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch (Exception commitException) {
            await RollbackAsync();
            throw new ApplicationException("Error committing changes. See inner exceptions for details.", commitException);
        }
        finally
        {
            await ResetTransactionAsync();
        }

    }
    public async Task SaveAndCommitAsync()
    {
        try
        {
            await SaveChangesAsync();
            await CommitAsync();
        }
        catch (Exception saveChangesException)
        {
            throw new ApplicationException("Error saving and committing changes. See inner exceptions for details.", saveChangesException);
        }
    }

    public async Task RollbackAsync()
    {
       await _transaction.RollbackAsync();
        await ResetTransactionAsync();
    }
    public async void Dispose()
    {
        await _transaction.DisposeAsync();
    }
    private async Task ResetTransactionAsync()
    {
        try
        {
            await _transaction.DisposeAsync();
        }
        catch (Exception disposeException)
        {
            // Log or handle the dispose exception as needed
        }

        _transaction = _context.Database.BeginTransaction(); // Start a new transaction
    }
}
