﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.Application.InputModel
{
    public class CreateGroupStationInputModel
    {
        public List<CreateChargeStationInputModel> ChargeStations { get;  set; }
        public string Name { get;  set; }
        public int CapacityAmps { get;  set; }
    }
}
