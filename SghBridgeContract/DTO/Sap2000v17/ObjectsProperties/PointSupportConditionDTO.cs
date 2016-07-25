
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeContract.DTO.Sap2000v17.ObjectsProperties
{
    public class PointSupportConditionDTO
    {
          bool RestraintUX {get; set;}
          bool RestraintUY {get; set;}
          bool RestraintUZ {get; set;}
          bool RestraintRX {get; set;}
          bool RestraintRY {get; set;}
          bool RestraintRZ {get; set;}

        public bool [] GetRestraintsAsArray()
        {
            bool[] res = new bool[6];
            res[0] = this.RestraintUX;
            res[1] = this.RestraintUY;
            res[2] = this.RestraintUZ;
            res[3] = this.RestraintRX;
            res[4] = this.RestraintRY;
            res[5] = this.RestraintRZ;
            return res;
        }
        public void SetRestraintsByArray(bool [] res)
        {
            if (res.Length == 6)
            {
                this.RestraintUX = res[0];
                this.RestraintUY = res[1];
                this.RestraintUZ = res[2];
                this.RestraintRX = res[3];
                this.RestraintRY = res[4];
                this.RestraintRZ = res[5];
            }
        }
    }
}
