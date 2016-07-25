using SghBridgeContract.DTO.Revit2016.Model;
using SghBridgeContract.DTO.Sap2000v17.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeController.CommonObjects
{
    public class ModelCommon
    {
        private SapModelDTO sapModelInfo;
        public SapModelDTO SapModelInfo
        {
            get { return sapModelInfo; }
            set
            {
                UpdateModelInformation();
                sapModelInfo = value;
            }
        }

        private RevitModelDTO revitModelInfo;
        public RevitModelDTO RevitModelInfo
        {
            get { return revitModelInfo; }
            set
            {
                UpdateModelInformation();
                revitModelInfo = value;
            }
        }



        private void UpdateModelInformation()
        {
            // Update other DTOs
            throw new NotImplementedException();
        }
    }
}
