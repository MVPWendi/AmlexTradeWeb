﻿// <auto-generated />
using AmlexTradeWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AmlexTradeWeb.Migrations
{
    [DbContext(typeof(ForumDB))]
    partial class ForumDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AmlexTradeWeb.Models.BoughtCar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarKey")
                        .HasColumnType("int");

                    b.Property<decimal>("OwnerID")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("SellerID")
                        .HasColumnType("decimal(20,0)");

                    b.Property<bool>("Taken")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("BoughtCars");
                });

            modelBuilder.Entity("AmlexTradeWeb.Models.BoughtItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemKey")
                        .HasColumnType("int");

                    b.Property<decimal>("OwnerID")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("SellerID")
                        .HasColumnType("decimal(20,0)");

                    b.Property<bool>("Taken")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("BoughtItems");
                });

            modelBuilder.Entity("AmlexTradeWeb.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bought")
                        .HasColumnType("bit");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OwnerID")
                        .HasColumnType("decimal(20,0)");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.Property<long>("VehicleInstanceID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AmlexTradeWeb.Models.Command", b =>
                {
                    b.Property<int>("CommandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PluginName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommandID");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("AmlexTradeWeb.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bought")
                        .HasColumnType("bit");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OwnerID")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("ID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("AmlexTradeWeb.Models.Plugin", b =>
                {
                    b.Property<int>("PluginID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PluginID");

                    b.ToTable("Plugins");
                });

            modelBuilder.Entity("AmlexTradeWeb.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("MoneyAmount")
                        .HasColumnType("float");

                    b.Property<decimal>("SteamID")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
