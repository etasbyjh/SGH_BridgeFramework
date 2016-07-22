
using SghBridgeContract.DTO.Revit2016.Objects;
using SghBridgeContract.DTO.Sap2000v17.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeController.CommonObjects
{
    public class PointCommon
    {
        private RevitPointDTO revitInfo;
        public RevitPointDTO RevitInfo
        {
            get { return revitInfo; }
            set
            {
                UpdateProperties();
                revitInfo = value;
            }
        }

        private SapNodeDTO sapInfo;
        public SapNodeDTO SapInfo
        {
            get { return sapInfo; }
            set
            {
                UpdateProperties();
                sapInfo = value;
            }
        }

        /// <summary>
        ///implement logic that updates all other properties if on property changes
        /// </summary>
        private void UpdateProperties()
        {
            // Update other DTOs
            throw new NotImplementedException();
        }
    }
}
