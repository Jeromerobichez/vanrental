﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace vanRental.Models;

public partial class Rentals
{
    public int Id { get; set; }

    public DateTime? DepartureDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public int ClientId { get; set; }

    public int VehicleId { get; set; }

    public virtual Clients Client { get; set; }

    public virtual Vehicles Vehicle { get; set; }
}