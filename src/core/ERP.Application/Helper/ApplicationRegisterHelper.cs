using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ERP.Application.Helper;

public static class ApplicationRegisterHelper
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
