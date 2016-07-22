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
                UpdateProperties();
                sapModelInfo = value;
            }
        }

        

        private void UpdateProperties()
        {
            // Update other DTOs
            throw new NotImplementedException();
        }
    }
}
