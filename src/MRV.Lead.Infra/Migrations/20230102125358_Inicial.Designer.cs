// <auto-generated />
using System;
using MRV.Lead.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MRV.Lead.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230102125358_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MRV.Lead.Domain.Models.ContactModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_alteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_inclusao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("fullname");

                    b.Property<decimal>("PhoneNumber")
                        .HasColumnType("decimal")
                        .HasColumnName("phonenumber");

                    b.HasKey("Id");

                    b.ToTable("tb_contact", (string)null);
                });

            modelBuilder.Entity("MRV.Lead.Domain.Models.LeadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Category")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("category");

                    b.Property<Guid>("ContactID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("contactId");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_alteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_inclusao");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("description");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal")
                        .HasColumnName("price");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(1)")
                        .HasColumnName("status");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("suburb");

                    b.HasKey("Id");

                    b.HasIndex("ContactID");

                    b.ToTable("tb_lead", (string)null);
                });

            modelBuilder.Entity("MRV.Lead.Domain.Models.LeadModel", b =>
                {
                    b.HasOne("MRV.Lead.Domain.Models.ContactModel", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });
#pragma warning restore 612, 618
        }
    }
}
