using Microsoft.EntityFrameworkCore;
using MRV.Lead.Domain.Models;
using MRV.Lead.Infra.Core.Maps;

namespace MRV.Lead.Infra.Maps;

public class ContactMap : EntitySimpleTypeMap<ContactModel>
{
    protected override void CreateTable() =>
        Builder.ToTable("tb_contact");

    protected override void CreateColumns()
    {
        Builder.Property(x => x.FullName)
            .HasColumnName("fullname")
            .HasColumnType("varchar(200)")
            .IsRequired();

        Builder.Property(x => x.PhoneNumber)
            .HasColumnName("phonenumber")
            .HasColumnType("decimal")
            .IsRequired();

        Builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasColumnType("varchar(200)")
            .IsRequired();

        base.CreateColumns();
    }
}