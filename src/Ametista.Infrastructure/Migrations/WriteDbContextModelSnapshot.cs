﻿// <auto-generated />
using System;
using Ametista.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ametista.Infrastructure.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    partial class WriteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ametista.Core.Entity.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardHolder");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Ametista.Core.Entity.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CardId");

                    b.Property<DateTimeOffset>("ChargeDate");

                    b.Property<string>("UniqueId");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Ametista.Core.Entity.Transaction", b =>
                {
                    b.OwnsOne("Ametista.Core.ValueObjects.Money", "Charge", b1 =>
                        {
                            b1.Property<Guid?>("TransactionId");

                            b1.Property<decimal>("Amount")
                                .HasColumnName("Amount");

                            b1.Property<string>("CurrencyCode")
                                .HasColumnName("CurrencyCode");

                            b1.ToTable("Transactions");

                            b1.HasOne("Ametista.Core.Entity.Transaction")
                                .WithOne("Charge")
                                .HasForeignKey("Ametista.Core.ValueObjects.Money", "TransactionId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}