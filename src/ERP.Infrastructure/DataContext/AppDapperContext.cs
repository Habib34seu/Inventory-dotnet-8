using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ERP.Infrastructure.DataContext;

public class AppDapperContext
{
    private readonly string? connectionString;
    public AppDapperContext(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnectionString");
    }

    public IDbConnection CreateConnection()
    {
        if (connectionString == null)
        {
            throw new InvalidOperationException("Connection string is not set");
        }

        return new SqlConnection(connectionString);
    }
}
