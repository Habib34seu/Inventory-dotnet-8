using ERP.Application.DTOs.Company;
using ERP.Application.IService.Company;
using ERP.Domain.Models.AdminModels;
using ERP.Infrastructure.Constant;
using ERP.Infrastructure.IRepository.UnitOfWork;
using FluentResults;
using Mapster;
using System.Linq.Expressions;


namespace ERP.Application.Service.Company;

public class CompanyService(IUnitOfWorkRepository _iUnitOfWork, StaticMessages _staticMessages) : ICompanyService
{
    public async Task<Result<CompanyDTO>> AddAsync(CompanyDTO entity)
    {
        try
        {
            var isExists = await _iUnitOfWork.CompanyRepository.IsExistsAsync(x => x.CompName == entity.CompName);
            if (isExists)
            {
                throw new Exception("");
            }

            entity.CreatedBy = "";
            entity.Status = !String.IsNullOrEmpty(entity.Status) ? "Active" : "InActive";
            entity.IsActive = entity.Status == "Active" ? true : false;

            var addedEntity = await _iUnitOfWork.CompanyRepository.AddAsync(entity.Adapt<CompanyEntity>());

            await _iUnitOfWork.CommitAsync();

            return Result.Ok(addedEntity.Adapt<CompanyDTO>());
        }
        catch (Exception ex) { 
            await _iUnitOfWork.RollbackAsync();
            throw;
        }
    }

    public Task<Result> DeleteAsync(CompanyDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<CompanyDTO>> GetAllAsync()
    {
        var companies = await _iUnitOfWork.CompanyRepository.GetAllAsync();
        return companies.Adapt<IReadOnlyList<CompanyDTO>>();
    }

    public Task<IReadOnlyList<CompanyDTO>> GetAsync(Expression<Func<CompanyDTO, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<CompanyDTO> GetByIdAsync(int id)
    {
        var company = await _iUnitOfWork.CompanyRepository.GetByIdAsync(id);
        return company.Adapt<CompanyDTO>();
    }

    public Task<bool> IsExistsAsync(Expression<Func<CompanyDTO, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(CompanyDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<Result<CompanyDTO>> UpdateAsync(CompanyDTO entity)
    {
        throw new NotImplementedException();
    }
}
