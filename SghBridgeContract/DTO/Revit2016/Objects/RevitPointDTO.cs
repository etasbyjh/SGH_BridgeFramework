using SghBridgeContract.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeContract.DTO.Revit2016.Objects
{

    /// <summary>
    /// Stores Revit Specific information
    /// </summary>
    public class RevitPointDTO : PointDTOBase
    {
        Guid Id { get; set; }
    }
}
