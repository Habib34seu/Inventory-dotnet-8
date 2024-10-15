using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.DTOs;

public class BaseDTO
{
    public int Id { get; set; }
    public DateTime? DateCreated { get; set; } = DateTime.Now;
    public DateTime? DateUpdated { get; set; }
    public string? CreatedBy { get; set; } = null!;
    public string? UpdatedBy { get; set; } = null!;
    public string? Status { get; set; } = "Active";
    public bool? IsActive { get; set; } = true;
}
