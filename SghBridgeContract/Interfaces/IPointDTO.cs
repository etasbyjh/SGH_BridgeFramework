using SghBridgeContract.DTO.sGeometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeContract.Interfaces
{
    public interface IPointDTO
    {
        string objName { get; set; }
        Guid objID { get; set; }
        sVector point { get; set; }
        bool IsGlobalCoSys { get; set; }
    }
}
