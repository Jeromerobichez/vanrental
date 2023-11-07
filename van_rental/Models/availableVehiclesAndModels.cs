
using System;
using System.Collections.Generic;

namespace van_rental.Models;

public partial class availableVehiclesAndModels
{
    public List<GetAvailablesVehiclesResult> VehiclesAvailable { get; set; }

    public List <getInfosOneModelAndPriceResult> ModelsAvailable { get; set; }


}