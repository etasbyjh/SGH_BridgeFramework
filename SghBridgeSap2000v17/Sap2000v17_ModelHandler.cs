
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SghBridgeContract.Interfaces;
using SghBridgeContract.Interfaces.Component;

using SghBridgeSap2000v17.Model;
using SghBridgeSap2000v17.Node;

using SAP2000v17;

namespace SghBridgeSap2000v17
{
    public class Sap2000v17_ModelHandler : IModelHandler
    {
        public bool IsInitiated { get; set; }

        public cOAPI sapApp { get; set; }
        public cSapModel sapModel { get; set; }
        public double sapMergeTol { get; set; }
        public SapPointHandler nodeHandler { get; set; }
        public SapModelHandler modelHandler { get; set; }

        public Sap2000v17_ModelHandler(string programPath, bool visible = false)
        {
            this.modelHandler = new SapModelHandler();
            this.nodeHandler = new SapPointHandler();

            try
            {
                SAP2000v17.cHelper sapHelp = new SAP2000v17.Helper();
                this.sapApp = sapHelp.CreateObject(programPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SAP2000v17 not found");
                return;
            }
            this.sapApp.ApplicationStart(SAP2000v17.eUnits.lb_ft_F, visible, "");
            this.sapApp.SetAsActiveObject();
        }

        public void InitiateSAPModel(eUnits sapUnit, string filePath = "")
        {
            if(filePath.Length > 0)
            {
                sapApp.SapModel.InitializeNewModel(sapUnit);
                this.sapModel = sapApp.SapModel;
            }
            else
            {
                sapApp.SapModel.File.OpenFile(filePath);
                sapModel = sapApp.SapModel;
            }
            this.IsInitiated = true;
        }
        public void DisposeSAPObjects(bool save = false)
        {
            sapApp.ApplicationExit(save);
            sapApp = null;
            sapModel = null;
            this.IsInitiated = false;
        }
        

        public void SetModel(IModelDTO Imodel)
        {
            if(this.IsInitiated )
            {
                modelHandler.SetSAPModelInfo(Imodel, this.sapModel);
            }
        }
        public IModelDTO GetModel()
        {
            if (this.sapApp != null)
            {
                return modelHandler.GetSAPModelInfo(this.sapModel);
            }
            else
            {
                return null;
            }
        }

        public void SetPoint(IPointDTO Ipoint)
        {
            if (this.IsInitiated )
            {
                nodeHandler.SetSAPPoint(Ipoint, this.sapModel);
            }
        }
        public IPointDTO GetPoint(string sapObjName)
        {
            if(this.IsInitiated )
            {
                return nodeHandler.GetSAPPoint(sapObjName, this.sapModel);
            }
            else
            {
                return null;
            }
        }

        public void SetAllPoints(List<IPointDTO> Ipoints)
        {
            if(this.IsInitiated )
            {
                nodeHandler.SetAllSAPPoints(Ipoints, this.sapModel);
            }
        }
        public List<IPointDTO> GetAllPoints()
        {
            if (this.IsInitiated )
            {
                return nodeHandler.GetAllSAPPoints(this.sapModel);
            }
            else
            {
                return null;
            }
        }



    }
}
