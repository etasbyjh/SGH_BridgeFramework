using SghBridgeContract.DTO.Base;
using SghBridgeContract.DTO.Sap2000v17.ObjectsProperties;
using SghBridgeContract.DTO.sGeometry;
using SghBridgeContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeContract.DTO.Sap2000v17.Objects
{
    /// <summary>
    /// Specific information special to SAP2000 node object
    /// </summary>
    public class SapNodeDTO : PointDTOBase
    {
        public bool IsStructural { get; set; }
        public List<PointLoadDTO> PointLoads { get; set; }
        public PointSupportConditionDTO SupportCondition {get; set;}
    }
}
