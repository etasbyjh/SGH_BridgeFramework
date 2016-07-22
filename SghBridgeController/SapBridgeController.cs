

using SghBridgeContract.DTO.Revit.Point;
using SghBridgeContract.DTO.Sap2000;
using SghBridgeController.Common;
using SghBridgeRevitV2016;
using SghBridgeSap2000v17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeController
{
    /// <summary>
    /// 
    /// </summary>
    public class SapBridgeController
    {
        public List<PointCommon> ScenePoints { get; set; }
        public void AddDataFromRevitToSap()
        {
            Sap2000ModelUpdater sapUpd = new Sap2000ModelUpdater();
            RevitModelUpdater revUpd = new RevitModelUpdater();

            //example
            foreach (var point in ScenePoints)
            {
                //RevitPointDTO rp = point.RevitInfo;
                SapNodeDTO sp = point.SapInfo;
                sapUpd.AddPoint(sp);
            }
        }

    }
}
