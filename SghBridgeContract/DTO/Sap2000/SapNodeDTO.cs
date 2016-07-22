using SghBridgeContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeContract.DTO.Sap2000
{
    /// <summary>
    /// Specific information special to SAP2000 node object
    /// </summary>
    public class SapNodeDTO : PointDTOBase
    {
        public List<PointLoadDTO> PointLoads { get; set; }
        public PointSupportConditionDTO SupportCondition {get; set;}
    }
}
