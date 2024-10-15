
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERP.Domain.Models.AdminModels;

public  class CompanyAreaEntity : BaseEntity
{
    [MaxLength(100), Column(TypeName = "nvarchar(100)")]
    public required string CompAreaName { get; set; }

    [MaxLength(int.MaxValue), Column(TypeName = "nvarchar(max)")]
    public string Address { get; set; } = default!;

    [MaxLength(14), Column(TypeName = "nvarchar(14)")]
    public string Phone { get; set; } = default!;

    [MaxLength(14), Column(TypeName = "nvarchar(14)")]
    public string Fax { get; set; } = default!;

    [MaxLength(50), Column(TypeName = "nvarchar(50)")]
    public string Email { get; set; } = default!;

    [Required, ForeignKey("Companies")]
    public int CompId { get; set; }
}
