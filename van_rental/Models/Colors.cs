﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace vanRental.Models;

public partial class Colors
{
    public int Id { get; set; }

    public string ColorName { get; set; }

    public virtual ICollection<Vehicles> Vehicles { get; set; } = new List<Vehicles>();
}