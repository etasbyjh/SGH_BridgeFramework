using SghBridgeContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeContract.DTO
{
    public class PointDTOBase : IPointDTO
    {
        public double X { get; set;}
        public double Y { get; set;}
        public double Z { get; set; }

    }
}
