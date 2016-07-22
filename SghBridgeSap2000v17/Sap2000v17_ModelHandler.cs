
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

        public Sap2000v17_ModelHandler()
        {
            //create a new
        }
        public Sap2000v17_ModelHandler(string existingFileDic)
        {
            //read from file
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
            
            
        }
        //Isn't it duplicated???... spanode handler has GetNode... basically doing same thing
        public IPointDTO GetPoint(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
