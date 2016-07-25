using SghBridgeContract.DTO.sGeometry;
using SghBridgeContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeContract.DTO.Base
{
    public class PointDTOBase : IPointDTO
    {
        public string objName { get; set; }
        public Guid objID { get; set; }
        public sVector point { get; set; }
        public bool IsGlobalCoSys { get; set; }
    }
}
