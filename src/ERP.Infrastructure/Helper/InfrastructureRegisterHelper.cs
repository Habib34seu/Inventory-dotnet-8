using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Infrastructure.DataContext;
using ERP.Infrastructure.IRepository.UnitOfWork;
using ERP.Infrastructure.Repository.UnitOfWork;

namespace ERP.Infrastructure.Helper;

public static class InfrastructureRegisterHelper
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<AppDapperContext>();
        services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

        return services;
    }
}
