using ERP.Application.DTOs;
using ERP.Application.DTOs.Company;
using ERP.Domain.Models.AdminModels;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Mapping;

public class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<CompanyEntity, CompanyDTO>.NewConfig();
    }
}
