﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace vanRental.Models;

public partial class Vehicles
{
    public int Id { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public int? Km { get; set; }

    public bool? AutomaticGear { get; set; }

    public string Comments { get; set; }

    public int ModelId { get; set; }

    public int ColorId { get; set; }

    public virtual Colors Color { get; set; }

    public virtual VehicleModels Model { get; set; }

    public virtual ICollection<Rentals> Rentals { get; set; } = new List<Rentals>();
}