﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace van_rental.Models;

public partial class van_rentalContext : DbContext
{
    public van_rentalContext(DbContextOptions<van_rentalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clients> Clients { get; set; }

    public virtual DbSet<Colors> Colors { get; set; }

    public virtual DbSet<Rentals> Rentals { get; set; }

    public virtual DbSet<Requests> Requests { get; set; }

    public virtual DbSet<VehicleModels> VehicleModels { get; set; }

    public virtual DbSet<Vehicles> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clients>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clients__3213E83FAAFF56FC");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Tel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tel");
        });

        modelBuilder.Entity<Colors>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__colors__3213E83F9F4897C8");

            entity.ToTable("colors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color_name");
        });

        modelBuilder.Entity<Rentals>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rentals__3213E83F3DA6213B");

            entity.ToTable("rentals");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DepartureDate)
                .HasColumnType("date")
                .HasColumnName("departure_date");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("date")
                .HasColumnName("return_date");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_client_id");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_vehicle_id");
        });

        modelBuilder.Entity<Requests>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Requests__33A8517A9421DD6D");

            entity.Property(e => e.ClientEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ClientName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ClientTel)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DepartureDateRequested).HasColumnType("date");
            entity.Property(e => e.ModelVehicleRequested).HasMaxLength(50);
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("request_date");
            entity.Property(e => e.ReturnDateRequested).HasColumnType("date");
        });

        modelBuilder.Entity<VehicleModels>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vehicle___3213E83FBD2DF891");

            entity.ToTable("vehicle_models");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EnginePower).HasColumnName("enginePower");
            entity.Property(e => e.GasTank).HasColumnName("gas_tank");
            entity.Property(e => e.Heating).HasColumnName("heating");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NbLuggage).HasColumnName("nbLuggage");
            entity.Property(e => e.Pax).HasColumnName("pax");
            entity.Property(e => e.PictureUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("picture_url");
            entity.Property(e => e.PresentationText)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("presentationText");
            entity.Property(e => e.PricePerDay).HasColumnName("price_per_day");
        });

        modelBuilder.Entity<Vehicles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vehicles__3213E83F3243E758");

            entity.ToTable("vehicles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AutomaticGear).HasColumnName("automatic_gear");
            entity.Property(e => e.ColorId).HasColumnName("color_id");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.HasBeenSold)
                .HasDefaultValueSql("((0))")
                .HasColumnName("hasBeenSold");
            entity.Property(e => e.Km).HasColumnName("km");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.RegistrationDate)
                .HasColumnType("date")
                .HasColumnName("registration_date");

            entity.HasOne(d => d.Color).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_color_id");

            entity.HasOne(d => d.Model).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_model_id");
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingGeneratedFunctions(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}