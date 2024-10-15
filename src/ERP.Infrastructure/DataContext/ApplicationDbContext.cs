using ERP.Domain.Models.AdminModels;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.DataContext;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    //public DbSet<AppUserEntity>AppUsers { get; set; }
    public DbSet<CompanyEntity> Companies { get; set; }
    public DbSet<CompanyAreaEntity> CompanyAreas { get; set; }
    //public DbSet<EmployeeEntity> Employees { get; set; }
}
