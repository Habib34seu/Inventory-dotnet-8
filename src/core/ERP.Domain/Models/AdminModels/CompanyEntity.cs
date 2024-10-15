using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models.AdminModels;

public  class CompanyEntity : BaseEntity
{
    [MaxLength(100), Column(TypeName = "nvarchar(100)")]
    public required string CompName { get; set; }

    [MaxLength(50), Column(TypeName = "nvarchar(50)")]
    public required string CompShortName { get; set; }
}
