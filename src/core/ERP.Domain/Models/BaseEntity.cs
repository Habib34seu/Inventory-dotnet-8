using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Domain.Models;

public class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "DateTime")]
    public DateTime? CreatedDate { get; set; } = DateTime.Now;
    public int? CreatedBy { get; set; }
    [Column(TypeName = "DateTime")]
    public DateTime? UpdatedDate { get; set; }
    public int? UpdatedBy { get; set; }
    public bool IsActive { get; set; } = false;
    public bool? IsDeleted { get; set; } = false;
    public int? DeletedBy { get; set; }
    [Column(TypeName = "DateTime")]
    public DateTime? DeletedDate { get; set; }
    
}
public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Ignore(b => b.CreatedBy);
        builder.Ignore(b => b.UpdatedDate);
        builder.Ignore(b => b.UpdatedBy);
        builder.Ignore(b => b.IsActive);
        builder.Ignore(b => b.DeletedBy);
        builder.Ignore(b => b.DeletedDate);
        ConfigureDerivedEntity(builder);
    }

    protected abstract void ConfigureDerivedEntity(EntityTypeBuilder<T> builder);
}

