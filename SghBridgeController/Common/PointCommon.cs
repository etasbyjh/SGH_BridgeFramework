using SghBridgeContract.DTO.Revit.Point;
using SghBridgeContract.DTO.Sap2000;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeController.Common
{
    public class PointCommon
    {
        private RevitPointDTO revitInfo;

        public RevitPointDTO RevitInfo
        {
            get { return revitInfo; }
            set {
                UpdateProperties();
                revitInfo = value; }
        }

        private void UpdateProperties()
        {
            // Update other DTOs
            throw new NotImplementedException();
        }

        public SapNodeDTO SapInfo { get; set; }
        // implement logic that updates all other properties if on property changes
    }
}
