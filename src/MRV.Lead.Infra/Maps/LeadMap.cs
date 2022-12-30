using Microsoft.EntityFrameworkCore;
using MRV.Lead.Domain.Enums;
using MRV.Lead.Domain.Models;
using MRV.Lead.Infra.Core.Maps;

namespace MRV.Lead.Infra.Maps;

public class LeadMap : EntitySimpleTypeMap<LeadModel>
{
    protected override void CreateTable() =>
        Builder.ToTable("tb_lead");

    protected override void CreateColumns()
    {
        Builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("varchar(200)")
            .IsRequired();

        Builder.Property(x => x.Price)
            .HasColumnName("price")
            .HasColumnType("decimal")
            .IsRequired();

        Builder.Property(x => x.Suburb)
            .HasColumnName("suburb")
            .HasColumnType("varchar(200)")
            .IsRequired();

        Builder.Property(x => x.Category)
            .HasColumnName("category")
            .HasColumnType("varchar(200)");

        Builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasColumnType("varchar(1)")
            .IsRequired()
            .HasConversion(new CharEnumToStringConverter<Status>());

        Builder.Property(e => e.ContactID)
                .HasColumnName("contactId");

        Builder.HasOne(x => x.Contact)
                .WithMany()
                .HasForeignKey(x => x.ContactID);

        base.CreateColumns();
    }
}