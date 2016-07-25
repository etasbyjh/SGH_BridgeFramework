
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SghBridgeContract.Interfaces;
using SghBridgeContract.Interfaces.Component;
using SghBridgeSap2000v17.Node;

using SAP2000v17;

namespace SghBridgeSap2000v17
{
    public class Sap2000v17_ModelHandler : IModelHandler
    {
        public cSapModel sapModel { get; set; }
        public SapNodeHandler nodeHandler { get; set; }

        public Sap2000v17_ModelHandler()
        {
            //create a new
            nodeHandler = new SapNodeHandler();
        }
        public Sap2000v17_ModelHandler(string existingFileDic)
        {
            //read from file

            nodeHandler = new SapNodeHandler();
        }
        public Sap2000v17_ModelHandler(cSapModel sap_mo)
        {
            this.sapModel = sap_mo;
            nodeHandler = new SapNodeHandler();
        }


        public void SetModel(IModelDTO mo)
        {

        }
        public IModelDTO GetModel()
        {
            throw new NotImplementedException();
        }

        public void SetPoint(IPointDTO p)
        {
            if (this.sapModel != null)
            {
                nodeHandler.SetNode(p, this.sapModel);
            }
        }
        
        public IPointDTO GetPoint(string sapObjName)
        {
            if(this.sapModel != null)
            {
                return nodeHandler.GetNode(sapObjName, this.sapModel);
            }
            else
            {
                return null;
            }
        }
    }
}
