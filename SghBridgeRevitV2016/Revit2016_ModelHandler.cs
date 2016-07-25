using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SghBridgeContract.Interfaces;
using SghBridgeContract.Interfaces.Component;



namespace SghBridgeRevit2016
{
    public class Revit2016_ModelHandler : IModelHandler
    {
        public bool IsInitiated { get; set; }



        public void SetModel(IModelDTO mo)
        {
            throw new NotImplementedException();
        }

        public IModelDTO GetModel()
        {
            throw new NotImplementedException();
        }

        public void SetPoint(IPointDTO p)
        {
            throw new NotImplementedException();
        }

        public IPointDTO GetPoint(string Id)
        {
            throw new NotImplementedException();
        }

        public void SetAllPoints(List<IPointDTO> Ipoints)
        {
            throw new NotImplementedException();
        }

        public List<IPointDTO> GetAllPoints()
        {
            throw new NotImplementedException();
        }
    }
}
