

using ERP.Domain.Models.AdminModels;
using ERP.Infrastructure.DataContext;
using ERP.Infrastructure.IRepository.Company;
using ERP.Infrastructure.Repository.Common.Generic;

namespace ERP.Infrastructure.Repository.Company;

public class CompanyRepository(ApplicationDbContext _context) : Repository<CompanyEntity>(_context), ICompanyRepository
{
}
