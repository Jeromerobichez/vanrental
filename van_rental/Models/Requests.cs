﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace van_rental.Models;

public partial class Requests
{
    public int RequestId { get; set; }

    public DateTime? DepartureDateRequested { get; set; }

    public DateTime? ReturnDateRequested { get; set; }

    public string ModelVehicleRequested { get; set; }

    public int? ModelId { get; set; }

    public string MessageRequest { get; set; }
}