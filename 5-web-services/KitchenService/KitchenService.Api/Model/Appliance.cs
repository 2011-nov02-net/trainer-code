﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenService.Api.Model
{
    public class Appliance : IAppliance
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
