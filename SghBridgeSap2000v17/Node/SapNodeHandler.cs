using SghBridgeContract.DTO.Sap2000v17.Objects;
using SghBridgeContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SAP2000v17;

namespace SghBridgeSap2000v17.Node
{
    /// <summary>
    /// Logic to manipulate nodes in SAP
    /// </summary>
   public  class SapNodeHandler
    {
        public void SetNode(IPointDTO p, cSapModel sap_mo)
        {
            //TODO: Add Sap specific logic here
            SapNodeDTO sap_dp = p as SapNodeDTO;
            
            //sap_mo.PointObj. .....
        }
        public IPointDTO GetNode(string id)
        {
            SapNodeDTO snd = new SapNodeDTO();

            //snd.PointLoads.Add();
            //snd.name = new;

            return snd;
        }
    }
}
