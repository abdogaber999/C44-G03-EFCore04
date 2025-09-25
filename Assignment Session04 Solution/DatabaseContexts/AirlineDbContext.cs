using System;
using System.Collections.Generic;
using Assignment_Session04_Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Session04_Solution.DatabaseContexts;

public partial class AirlineDbContext : DbContext
{
    public AirlineDbContext()
    {
    }

    public AirlineDbContext(DbContextOptions<AirlineDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AirCraft> AirCrafts { get; set; }

    public virtual DbSet<Airline> Airlines { get; set; }

    public virtual DbSet<AirlinePhone> AirlinePhones { get; set; }

    public virtual DbSet<Crew> Crews { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ABDELRAHMAN;Database=Airline;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AirCraft>(entity =>
        {
            entity.HasIndex(e => e.AirlineId, "IX_AirCrafts_AirlineId");

            entity.Property(e => e.Model).HasMaxLength(100);

            entity.HasOne(d => d.Airline).WithMany(p => p.AirCraft).HasForeignKey(d => d.AirlineId);
        });

        modelBuilder.Entity<Airline>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<AirlinePhone>(entity =>
        {
            entity.HasIndex(e => e.AirlineId, "IX_AirlinePhones_AirlineId");

            entity.HasIndex(e => e.AirlineId1, "IX_AirlinePhones_AirlineId1");

            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.Airline).WithMany(p => p.AirlinePhoneAirlines).HasForeignKey(d => d.AirlineId);

            entity.HasOne(d => d.AirlineId1Navigation).WithMany(p => p.AirlinePhoneAirlineId1Navigations).HasForeignKey(d => d.AirlineId1);
        });

        modelBuilder.Entity<Crew>(entity =>
        {
            entity.HasIndex(e => e.AirCraftId, "IX_Crews_AirCraftId");

            entity.Property(e => e.AssisPilot).HasMaxLength(100);
            entity.Property(e => e.Host1).HasMaxLength(100);
            entity.Property(e => e.Host2).HasMaxLength(100);
            entity.Property(e => e.MajPilot).HasMaxLength(100);

            entity.HasOne(d => d.AirCraft).WithMany(p => p.Crews).HasForeignKey(d => d.AirCraftId);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.AirlineId, "IX_Employees_AirlineId");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.BdDay).HasColumnName("BD_Day");
            entity.Property(e => e.BdMonth).HasColumnName("BD_Month");
            entity.Property(e => e.BdYear).HasColumnName("BD_Year");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.Qualifications).HasMaxLength(200);

            entity.HasOne(d => d.Airline).WithMany(p => p.Employees).HasForeignKey(d => d.AirlineId);
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasIndex(e => e.AirCraftId, "IX_Routes_AirCraftId");

            entity.Property(e => e.Classification).HasMaxLength(50);
            entity.Property(e => e.Destination).HasMaxLength(100);
            entity.Property(e => e.Origin).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.AirCraft).WithMany(p => p.Routes).HasForeignKey(d => d.AirCraftId);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasIndex(e => e.AirlineId, "IX_Transactions_AirlineId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(200);

            entity.HasOne(d => d.Airline).WithMany(p => p.Transactions).HasForeignKey(d => d.AirlineId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
