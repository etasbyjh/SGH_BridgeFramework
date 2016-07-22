using SghBridgeContract.DTO.Sap2000v17.Objects;
using SghBridgeContract.DTO.Sap2000v17.Model;

using SghBridgeContract.DTO.Revit2016.Objects;

using SghBridgeController.CommonObjects;

using SghBridgeRevitV2016;
using SghBridgeSap2000v17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SghBridgeController
{
    public class BridgeController
    {
        public List<PointCommon> modelPointObjs { get; set; }
        public BridgeController model { get; set; }

        public void ControlData_FromRevit2016ToSAP2000v17()
        {
            Sap2000v17_ModelHandler sapUpd = new Sap2000v17_ModelHandler();
            Revit2016_ModelHandler revUpd = new Revit2016_ModelHandler();

            //example

            //get points from Revit first
            SapModelDTO sapMo = model as SapModelDTO;
            sapUpd.SetModel(sapMo);

            foreach (var point in modelPointObjs)
            {
                //RevitPointDTO rp = point.RevitInfo;
                SapNodeDTO sp = point.SapInfo;

                sapUpd.SetPoint(sp);


                // dont forget to erase this example
            }
        }
    }
}
