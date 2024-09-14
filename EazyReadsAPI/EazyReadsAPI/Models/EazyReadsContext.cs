using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EazyReadsAPI.Models;

public partial class EazyReadsContext : DbContext
{
    public EazyReadsContext()
    {
    }

    public EazyReadsContext(DbContextOptions<EazyReadsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompanyDetail> CompanyDetails { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserHistory> UserHistories { get; set; }

    public virtual DbSet<UserPaymentInfo> UserPaymentInfos { get; set; }

    public virtual DbSet<UserRequest> UserRequests { get; set; }

    public virtual DbSet<ViewedCompany> ViewedCompanies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=LAPTOP-KFTFNI92\\FAVOURSQLEXPRESS;database=EazyReads;integrated security = true; TrustServerCertificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyDetail>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__CompanyD__2D971C4C19E989F9");

            entity.Property(e => e.CompanyId)
                .ValueGeneratedNever()
                .HasColumnName("CompanyID");
            entity.Property(e => e.CompanyLogoUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CompanyLogoURL");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CompanyTos)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CompanyTOS");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserDeta__1788CCAC054FBA67");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.HasPriviledgedAccess).HasColumnName("hasPriviledgedAccess");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserHistory>(entity =>
        {
            entity.HasKey(e => e.UserHid).HasName("PK__UserHist__2A95D6FC126D3E81");

            entity.ToTable("UserHistory");

            entity.Property(e => e.UserHid)
                .ValueGeneratedNever()
                .HasColumnName("UserHID");
            entity.Property(e => e.CompaniesViewed)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("companiesViewed");
            entity.Property(e => e.DateViewed)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("dateViewed");
        });

        modelBuilder.Entity<UserPaymentInfo>(entity =>
        {
            entity.HasKey(e => e.UserPid).HasName("PK__UserPaym__2C963C3F0FFCF0A6");

            entity.ToTable("UserPaymentInfo", tb => tb.HasTrigger("update_Priviledge"));

            entity.Property(e => e.UserPid)
                .ValueGeneratedNever()
                .HasColumnName("UserPID");
            entity.Property(e => e.HasPaid).HasColumnName("hasPaid");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.UserP).WithOne(p => p.UserPaymentInfo)
                .HasForeignKey<UserPaymentInfo>(d => d.UserPid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_UserPID");
        });

        modelBuilder.Entity<UserRequest>(entity =>
        {
            entity.HasKey(e => e.UserRid).HasName("PK__UserRequ__2B2A784D6B1F15A4");

            entity.ToTable("UserRequest");

            entity.Property(e => e.UserRid)
                .ValueGeneratedNever()
                .HasColumnName("UserRID");
            entity.Property(e => e.CompanyDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UserR).WithOne(p => p.UserRequest)
                .HasForeignKey<UserRequest>(d => d.UserRid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_UserRID");
        });

        modelBuilder.Entity<ViewedCompany>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewedCompanies");

            entity.Property(e => e.CompanyLogoUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CompanyLogoURL");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DateViewed)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("dateViewed");
            entity.Property(e => e.UserHid).HasColumnName("UserHID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
