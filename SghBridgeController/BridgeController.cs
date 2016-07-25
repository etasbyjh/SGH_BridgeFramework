using SghBridgeContract;
using SghBridgeContract.Interfaces;
using SghBridgeContract.Interfaces.Component;

using SghBridgeContract.DTO.Sap2000v17.Objects;
using SghBridgeContract.DTO.Sap2000v17.Model;

using SghBridgeContract.DTO.Revit2016.Objects;

using SghBridgeController.CommonObjects;

using SghBridgeRevit2016;
using SghBridgeSap2000v17;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SghBridgeContract.DTO.Revit2016.Model;

namespace SghBridgeController
{
    public class BridgeController
    {
        public List<PointCommon> modelPointObjs { get; set; }
        public ModelCommon modelInfo { get; set; }

        public string BuildBridgeController(IModelHandler modelHandler)
        {
            if (modelHandler.IsInitiated)
            {
                GetModelCommon(modelHandler);

                foreach(IPointDTO ip in modelHandler.GetAllPoints())
                {
                    GetPointCommon(ip);
                }
                //add else


                return "Built";
            }
            else
            {
                return "Initiate Model Handler";
            }
        }

        public string BuildApplication(IModelHandler modelHandler)
        {
            if (modelHandler.IsInitiated)
            {
                SetModelCommon(modelHandler);
                foreach (PointCommon pc in this.modelPointObjs)
                {
                    SetPointCommon(pc, modelHandler);
                }

                //add else

                return "Built";
            }
            else
            {
                return "Initiate Model Handler";
            }
        }


        private void GetModelCommon( IModelHandler han)
        {
            ModelCommon mo = new ModelCommon();
            if (han is Sap2000v17_ModelHandler)
            {
                mo.SapModelInfo = han.GetModel() as SapModelDTO;
            }
            else if(han is Revit2016_ModelHandler)
            {
                mo.RevitModelInfo = han.GetModel() as RevitModelDTO;
            }

            this.modelInfo = mo;
        }
        private void SetModelCommon(IModelHandler han)
        {
            if (han is Sap2000v17_ModelHandler)
            {
                han.SetModel(modelInfo.SapModelInfo);
            }
            else if (han is Revit2016_ModelHandler)
            {
                han.SetModel(modelInfo.RevitModelInfo);
            }
        }

        private void GetPointCommon(IPointDTO ip)
        {
            PointCommon pc = new PointCommon();
            if (ip is SapNodeDTO)
            {
                pc.SapInfo = ip as SapNodeDTO;
            }
            else if (ip is RevitPointDTO)
            {
                pc.RevitInfo = ip as RevitPointDTO;
            }

            modelPointObjs.Add(pc);
        }
        private void SetPointCommon(PointCommon pc, IModelHandler han)
        {
            if (han is Sap2000v17_ModelHandler)
            {
                han.SetPoint(pc.SapInfo);
            }
            else if(han is Revit2016_ModelHandler)
            {
                han.SetPoint(pc.RevitInfo);
            }
        }



        /*
        public void BuildBridgeControllerFromSAP2000v17(Sap2000v17_ModelHandler sap17_handler)
        {
            if (sap17_handler.IsInitiated == true)
            {
                ModelCommon mo = new ModelCommon();
                mo.SapModelInfo = sap17_handler.GetModel() as SapModelDTO;

                foreach (SapNodeDTO sn in sap17_handler.GetAllPoints())
                {
                    PointCommon pc = new PointCommon();
                    pc.SapInfo = sn as SapNodeDTO;
                    modelPointObjs.Add(pc);
                }
            }

        }
        public void BuildSAP2000v17FromBridgeController(Sap2000v17_ModelHandler sap17_handler)
        {
            if (sap17_handler.IsInitiated == true)
            {
                sap17_handler.SetModel(modelInfo.SapModelInfo);

                foreach (PointCommon pc in this.modelPointObjs)
                {
                    sap17_handler.SetPoint(pc.SapInfo);
                }
            }
            else
            {
                log = "Initiate SAP Model";
            }
        }
        */
    }
}
