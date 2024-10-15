using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.DTOs.Company;

public class CompanyDTO : BaseDTO
{
    public  string CompName { get; set; } = string.Empty;
    public  string CompShortName { get; set; } = string.Empty;
}
