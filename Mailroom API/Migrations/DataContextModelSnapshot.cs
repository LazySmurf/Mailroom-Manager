// <auto-generated />
using System;
using Mailroom_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mailroom_API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Mailroom_API.Models.LetterBag", b =>
                {
                    b.Property<string>("BagNo")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("LetterCount")
                        .HasColumnType("int");

                    b.Property<string>("ParcelList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(20,2)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(20,3)");

                    b.HasKey("BagNo");

                    b.ToTable("LetterBags");
                });

            modelBuilder.Entity("Mailroom_API.Models.Parcel", b =>
                {
                    b.Property<string>("ParcelNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<bool>("IsLetter")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(20,2)");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(20,3)");

                    b.HasKey("ParcelNumber");

                    b.ToTable("Parcels");
                });

            modelBuilder.Entity("Mailroom_API.Models.ParcelBag", b =>
                {
                    b.Property<string>("BagNo")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ParcelNos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BagNo");

                    b.ToTable("ParcelBags");
                });

            modelBuilder.Entity("Mailroom_API.Models.Shipment", b =>
                {
                    b.Property<string>("ShipmentNo")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Airport")
                        .HasColumnType("int");

                    b.Property<string>("BagList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightNo")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<bool>("IsFinalized")
                        .HasColumnType("bit");

                    b.HasKey("ShipmentNo");

                    b.ToTable("Shipments");
                });
#pragma warning restore 612, 618
        }
    }
}
