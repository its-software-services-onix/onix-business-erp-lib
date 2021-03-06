﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnixBusinessErpApp;

namespace OnixBusinessErpMigrate.Its.Onix.Erp.MigrationsPgSql
{
    [DbContext(typeof(OnixErpDbContextPgSql))]
    partial class OnixErpDbContextPgSqlModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Its.Onix.Erp.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressNo")
                        .IsRequired();

                    b.Property<int?>("CustomerId");

                    b.Property<string>("District");

                    b.Property<string>("Key");

                    b.Property<DateTime>("LastMaintDate");

                    b.Property<int>("OperatorId");

                    b.Property<int?>("ProvinceMasterId");

                    b.Property<string>("Road");

                    b.Property<string>("Tag");

                    b.Property<string>("Zip");

                    b.HasKey("AddressId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProvinceMasterId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Its.Onix.Erp.Models.BankAccount", b =>
                {
                    b.Property<int>("BankAccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AcctName")
                        .IsRequired();

                    b.Property<string>("AcctNo")
                        .IsRequired();

                    b.Property<int?>("BankMasterId");

                    b.Property<string>("BranchName");

                    b.Property<int?>("CustomerId");

                    b.Property<string>("Key");

                    b.Property<DateTime>("LastMaintDate");

                    b.Property<int>("OperatorId");

                    b.Property<string>("Tag");

                    b.HasKey("BankAccountId");

                    b.HasIndex("BankMasterId");

                    b.HasIndex("CustomerId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("Its.Onix.Erp.Models.CompanyProfile", b =>
                {
                    b.Property<int?>("CompanyProfileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressEng");

                    b.Property<string>("AddressThai");

                    b.Property<string>("BuildingName");

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("CompanyNameEng")
                        .IsRequired();

                    b.Property<string>("CompanyNameThai")
                        .IsRequired();

                    b.Property<int?>("CompanyPrefixMasterId");

                    b.Property<string>("District");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("FloorNo");

                    b.Property<string>("HomeNo");

                    b.Property<string>("Key");

                    b.Property<DateTime>("LastMaintDate");

                    b.Property<string>("Logo");

                    b.Property<string>("Moo");

                    b.Property<int>("OperatorId");

                    b.Property<string>("OperatorNameEng");

                    b.Property<string>("OperatorNameThai");

                    b.Property<string>("Province");

                    b.Property<string>("RegistrationAddress");

                    b.Property<string>("RegistrationName");

                    b.Property<string>("Road");

                    b.Property<string>("RoomNo");

                    b.Property<string>("Soi");

                    b.Property<string>("Tag");

                    b.Property<string>("TaxNo");

                    b.Property<string>("Telephone");

                    b.Property<string>("Town");

                    b.Property<string>("VillageName");

                    b.Property<string>("WebSite");

                    b.Property<string>("Zip");

                    b.HasKey("CompanyProfileId");

                    b.HasIndex("CompanyPrefixMasterId");

                    b.ToTable("CompanyProfiles");
                });

            modelBuilder.Entity("Its.Onix.Erp.Models.Customer", b =>
                {
                    b.Property<int?>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<int?>("CreditTermMasterId");

                    b.Property<int?>("CustomerGroupMasterId");

                    b.Property<int?>("CustomerTypeMasterId");

                    b.Property<string>("Key");

                    b.Property<DateTime>("LastMaintDate");

                    b.Property<string>("LastName");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("NamePrefixMasterId");

                    b.Property<int>("OperatorId");

                    b.Property<string>("Tag");

                    b.Property<string>("TaxNo")
                        .IsRequired();

                    b.HasKey("CustomerId");

                    b.HasIndex("CreditTermMasterId");

                    b.HasIndex("CustomerGroupMasterId");

                    b.HasIndex("CustomerTypeMasterId");

                    b.HasIndex("NamePrefixMasterId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Its.Onix.Erp.Models.Master", b =>
                {
                    b.Property<int?>("MasterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Key");

                    b.Property<DateTime>("LastMaintDate");

                    b.Property<string>("LongDescription");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OperatorId");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Tag");

                    b.Property<int>("Type");

                    b.HasKey("MasterId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Masters");
                });

            modelBuilder.Entity("Its.Onix.Erp.Models.Address", b =>
                {
                    b.HasOne("Its.Onix.Erp.Models.Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Its.Onix.Erp.Models.Master", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceMasterId");
                });

            modelBuilder.Entity("Its.Onix.Erp.Models.BankAccount", b =>
                {
                    b.HasOne("Its.Onix.Erp.Models.Master", "Bank")
                        .WithMany()
                        .HasForeignKey("BankMasterId");

                    b.HasOne("Its.Onix.Erp.Models.Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Its.Onix.Erp.Models.CompanyProfile", b =>
                {
                    b.HasOne("Its.Onix.Erp.Models.Master", "CompanyPrefix")
                        .WithMany()
                        .HasForeignKey("CompanyPrefixMasterId");
                });

            modelBuilder.Entity("Its.Onix.Erp.Models.Customer", b =>
                {
                    b.HasOne("Its.Onix.Erp.Models.Master", "CreditTerm")
                        .WithMany()
                        .HasForeignKey("CreditTermMasterId");

                    b.HasOne("Its.Onix.Erp.Models.Master", "CustomerGroup")
                        .WithMany()
                        .HasForeignKey("CustomerGroupMasterId");

                    b.HasOne("Its.Onix.Erp.Models.Master", "CustomerType")
                        .WithMany()
                        .HasForeignKey("CustomerTypeMasterId");

                    b.HasOne("Its.Onix.Erp.Models.Master", "NamePrefix")
                        .WithMany()
                        .HasForeignKey("NamePrefixMasterId");
                });
#pragma warning restore 612, 618
        }
    }
}
