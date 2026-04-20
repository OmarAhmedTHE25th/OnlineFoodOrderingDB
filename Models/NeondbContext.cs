using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OFODBGUI.Models;

public partial class NeondbContext : DbContext
{
    public NeondbContext()
    {
    }

    public NeondbContext(DbContextOptions<NeondbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DeliveryGuy> DeliveryGuys { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<SpecialOffer> SpecialOffers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-still-snow-amau45ls-pooler.c-5.us-east-1.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_MQDhp5uofCe7;SSL Mode=Require");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.Branchid).HasName("branch_pkey");

            entity.ToTable("branch");

            entity.Property(e => e.Branchid)
                .ValueGeneratedNever()
                .HasColumnName("branchid");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Closingtime).HasColumnName("closingtime");
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .HasColumnName("district");
            entity.Property(e => e.Openingtime).HasColumnName("openingtime");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customersid).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.HasIndex(e => e.Customeremail, "customer_customeremail_key").IsUnique();

            entity.Property(e => e.Customersid)
                .ValueGeneratedNever()
                .HasColumnName("customersid");
            entity.Property(e => e.Apartmentno)
                .HasMaxLength(20)
                .HasColumnName("apartmentno");
            entity.Property(e => e.Buildingno)
                .HasMaxLength(20)
                .HasColumnName("buildingno");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Customeremail)
                .HasMaxLength(255)
                .HasColumnName("customeremail");
            entity.Property(e => e.Customerpassword)
                .HasMaxLength(255)
                .HasColumnName("customerpassword");
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .HasColumnName("district");
            entity.Property(e => e.Floorno)
                .HasMaxLength(20)
                .HasColumnName("floorno");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Streetname)
                .HasMaxLength(100)
                .HasColumnName("streetname");
            entity.Property(e => e.Totalpoints)
                .HasDefaultValue(0)
                .HasColumnName("totalpoints");
        });

        modelBuilder.Entity<DeliveryGuy>(entity =>
        { 
            entity.HasKey(e => e.Deliveryguysid).HasName("delivery_guy_pkey");

            entity.ToTable("delivery_guy");

            entity.HasIndex(e => e.Deliveryguyssn, "delivery_guy_deliveryguyssn_key").IsUnique();

            entity.Property(e => e.Deliveryguysid)
                .ValueGeneratedNever()
                .HasColumnName("deliveryguysid");
            entity.Property(e => e.Branchid).HasColumnName("branchid");
            entity.Property(e => e.Contractexpirationdate).HasColumnName("contractexpirationdate");
            entity.Property(e => e.Dateofjoining).HasColumnName("dateofjoining");
            entity.Property(e => e.Deliveryguyname)
                .HasMaxLength(150)
                .HasColumnName("deliveryguyname");
            entity.Property(e => e.Deliveryguyssn)
                .HasMaxLength(20)
                .HasColumnName("deliveryguyssn");
            entity.Property(e => e.Numberofordersdelivered)
                .HasDefaultValue(0)
                .HasColumnName("numberofordersdelivered");
            entity.Property(e => e.Rating)
                .HasPrecision(3, 2)
                .HasColumnName("rating");
            entity.Property(e => e.Vehicletype)
                .HasMaxLength(50)
                .HasColumnName("vehicletype");

            entity.HasOne(d => d.Branch).WithMany(p => p.DeliveryGuys)
                .HasForeignKey(d => d.Branchid)
                .HasConstraintName("fk_delivery_branch");
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.Itemid).HasName("menu_item_pkey");

            entity.ToTable("menu_item");

            entity.Property(e => e.Itemid)
                .ValueGeneratedNever()
                .HasColumnName("itemid");
            entity.Property(e => e.Availability).HasColumnName("availability");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .HasColumnName("category");
            entity.Property(e => e.Itemdescription)
                .HasMaxLength(500)
                .HasColumnName("itemdescription");
            entity.Property(e => e.Itemname)
                .HasMaxLength(150)
                .HasColumnName("itemname");

            entity.HasMany(d => d.Offers).WithMany(p => p.Items)
                .UsingEntity<Dictionary<string, object>>(
                    "MenuItemOffer",
                    r => r.HasOne<SpecialOffer>().WithMany()
                        .HasForeignKey("Offerid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_itemoffer_offer"),
                    l => l.HasOne<MenuItem>().WithMany()
                        .HasForeignKey("Itemid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_itemoffer_item"),
                    j =>
                    {
                        j.HasKey("Itemid", "Offerid").HasName("menu_item_offer_pkey");
                        j.ToTable("menu_item_offer");
                        j.IndexerProperty<int>("Itemid").HasColumnName("itemid");
                        j.IndexerProperty<int>("Offerid").HasColumnName("offerid");
                    });
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Orderid)
                .ValueGeneratedNever()
                .HasColumnName("orderid");
            entity.Property(e => e.Branchid).HasColumnName("branchid");
            entity.Property(e => e.Customersid).HasColumnName("customersid");
            entity.Property(e => e.Datetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetime");
            entity.Property(e => e.Deliveryguysid).HasColumnName("deliveryguysid");
            entity.Property(e => e.Paymentmethod)
                .HasMaxLength(50)
                .HasColumnName("paymentmethod");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Branch).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Branchid)
                .HasConstraintName("fk_order_branch");

            entity.HasOne(d => d.Customers).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Customersid)
                .HasConstraintName("fk_order_customer");

            entity.HasOne(d => d.Deliveryguys).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Deliveryguysid)
                .HasConstraintName("fk_order_delivery_guy");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new { e.Orderid, e.Itemid }).HasName("order_item_pkey");

            entity.ToTable("order_item");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.Itemid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orderitem_item");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orderitem_order");
        });

        modelBuilder.Entity<SpecialOffer>(entity =>
        {
            entity.HasKey(e => e.Offerid).HasName("special_offers_pkey");

            entity.ToTable("special_offers");

            entity.Property(e => e.Offerid)
                .ValueGeneratedNever()
                .HasColumnName("offerid");
            entity.Property(e => e.Dayoftheweek)
                .HasMaxLength(20)
                .HasColumnName("dayoftheweek");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Minpoints).HasColumnName("minpoints");
            entity.Property(e => e.Offername)
                .HasMaxLength(150)
                .HasColumnName("offername");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
