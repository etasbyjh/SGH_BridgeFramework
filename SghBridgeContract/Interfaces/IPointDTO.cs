﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeContract.Interfaces
{
    public interface IPointDTO
    {
        string name { get; set; }
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
    }
}
