using SghBridgeContract.DTO.sGeometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeContract.DTO.Sap2000v17.ObjectsProperties
{
   public class PointLoadDTO
    {
        public string loadPatternName { get; set; }
        public string loadCaseName { get; set; }
        public sVector loadForce { get; set; }
        public sVector loadMoment { get; set; }

        public eSAPpointLoadType pointLoadType { get; set; }
        public bool IsGlobalCoSys { get; set; }
        public bool IsLoadCase { get; set; }

        public double [] GetLoadValuesAsArray()
        {
            double [] ls = new double[6];
            ls[0] = loadForce.X;
            ls[1] = loadForce.Y;
            ls[2] = loadForce.Z;
            ls[3] = loadMoment.X;
            ls[4] = loadMoment.Y;
            ls[5] = loadMoment.Z;
            return ls;
        }

        public void SetLoadsByArray(double [] loadValues)
        {
            if (loadValues.Length == 6)
            {
                loadForce = new sVector(loadValues[0], loadValues[1], loadValues[2]);
                loadMoment = new sVector(loadValues[3], loadValues[4], loadValues[5]);
            }
        }
    }

    public enum eSAPpointLoadType
    {
        Force_Moment,
        GroundTranslation_GroundRotation
    }
}
