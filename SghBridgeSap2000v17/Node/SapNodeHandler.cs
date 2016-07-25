using SghBridgeContract.DTO.Sap2000v17.Objects;
using SghBridgeContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SAP2000v17;
using SghBridgeContract.DTO.Sap2000v17.ObjectsProperties;
using SghBridgeContract.DTO.sGeometry;

namespace SghBridgeSap2000v17.Node
{
    /// <summary>
    /// Logic to manipulate nodes in SAP
    /// </summary>
   public  class SapNodeHandler
    {
        public void SetNode(IPointDTO p, cSapModel sap_mo)
        {
            SapNodeDTO sap_dp = p as SapNodeDTO;

            string coSys = "Local";
            if (sap_dp.IsGlobalCoSys)
            {
                coSys = "Global";
            }
            string objName = sap_dp.objName;
            sap_mo.PointObj.AddCartesian(sap_dp.point.X, sap_dp.point.Y, sap_dp.point.Z, ref objName, coSys);

            if (sap_dp.SupportCondition != null)
            {
                bool[] restraints = sap_dp.SupportCondition.GetRestraintsAsArray();
                sap_mo.PointObj.SetRestraint(objName, ref restraints, eItemType.Objects);
            }

            if(sap_dp.PointLoads != null)
            {
                foreach(PointLoadDTO pl in sap_dp.PointLoads)
                {
                    double [] loads = pl.GetLoadValuesAsArray();
                    if(pl.pointLoadType == eSAPpointLoadType.Force_Moment)
                    {
                        sap_mo.PointObj.SetLoadForce(objName, pl.loadPatternName, ref loads, true, coSys, eItemType.Objects);
                    }
                    else if(pl.pointLoadType == eSAPpointLoadType.GroundTranslation_GroundRotation)
                    {
                        sap_mo.PointObj.SetLoadDispl(objName, pl.loadPatternName, ref loads, true, coSys, eItemType.Objects);
                    }
                }
            }

            //anything else?
        }
        public IPointDTO GetNode(string sapObjName, cSapModel sap_mo, string coSys = "Global")
        {
            SapNodeDTO sapnode = new SapNodeDTO();
            sapnode.objName = sapObjName;

            string sapID = "";
            sap_mo.PointObj.GetGUID(sapObjName, ref sapID);
            sapnode.objID = Guid.Parse(sapID);

            double x = 0.0;
            double y = 0.0;
            double z = 0.0;
            sapnode.IsGlobalCoSys = false;
            if (coSys == "Global")
            {
                sapnode.IsGlobalCoSys = true;
            }
            sap_mo.PointObj.GetCoordCartesian(sapObjName, ref x, ref y, ref z, coSys);
            sapnode.point = new sVector(x, y, z);

            UpdateRestraints(sapObjName, sap_mo, ref sapnode);

            UpdatePointLoad_ForceMoment(sapObjName, sap_mo, ref sapnode);
            UpdateGroundTran_Rotation(sapObjName, sap_mo, ref sapnode);

            return sapnode;
        }

        private void UpdateRestraints(string sapObjName, cSapModel sap_mo, ref SapNodeDTO snd)
        {
            bool[] restraints = null;
            sap_mo.PointObj.GetRestraint(sapObjName, ref restraints);
            if (restraints != null)
            {
                snd.SupportCondition.SetRestraintsByArray(restraints);
            }
        }
        private void UpdateGroundTran_Rotation(string sapObjName, cSapModel sap_mo, ref SapNodeDTO snd)
        {
            int loadCount = 0;
            string[] PointName = null;
            string[] LoadPat = null;
            int[] LCStep = null;
            string[] CSys = null;
            double[] F1 = null;
            double[] F2 = null;
            double[] F3 = null;
            double[] M1 = null;
            double[] M2 = null;
            double[] M3 = null;
            sap_mo.PointObj.GetLoadDispl(sapObjName, ref loadCount, ref PointName, ref LoadPat, ref LCStep, ref CSys, ref F1, ref F2, ref F3, ref M1, ref M2, ref M3, eItemType.Objects);
            if (loadCount > 0)
            {
                for (int i = 0; i < LoadPat.Length; ++i)
                {
                    PointLoadDTO pl = new PointLoadDTO();
                    pl.loadPatternName = LoadPat[i];
                    if (CSys[i].Contains("Global"))
                    {
                        pl.IsGlobalCoSys = true;
                    }
                    else
                    {
                        pl.IsGlobalCoSys = false;
                    }
                    //what is LStep?
                    pl.loadForce = new sVector(F1[i], F2[i], F3[i]);
                    pl.loadMoment = new sVector(M1[i], M2[i], M3[i]);
                    pl.pointLoadType = eSAPpointLoadType.GroundTranslation_GroundRotation;

                    snd.PointLoads.Add(pl);
                }
            }
        }
        private void UpdatePointLoad_ForceMoment(string sapObjName, cSapModel sap_mo, ref SapNodeDTO snd)
        {
            int loadCount = 0;
            string[] PointName = null;
            string[] LoadPat = null;
            int[] LCStep = null;
            string[] CSys = null;
            double[] F1 = null;
            double[] F2 = null;
            double[] F3 = null;
            double[] M1 = null;
            double[] M2 = null;
            double[] M3 = null;
            sap_mo.PointObj.GetLoadForce(sapObjName, ref loadCount, ref PointName, ref LoadPat, ref LCStep, ref CSys, ref F1, ref F2, ref F3, ref M1, ref M2, ref M3, eItemType.Objects);
            if (loadCount > 0)
            {
                for (int i = 0; i < LoadPat.Length; ++i)
                {
                    PointLoadDTO pl = new PointLoadDTO();
                    pl.loadPatternName = LoadPat[i];
                    if (CSys[i].Contains("Global"))
                    {
                        pl.IsGlobalCoSys = true;
                    }
                    else
                    {
                        pl.IsGlobalCoSys = false;
                    }
                    //what is LStep?
                    pl.loadForce = new sVector(F1[i], F2[i], F3[i]);
                    pl.loadMoment = new sVector(M1[i], M2[i], M3[i]);
                    pl.pointLoadType = eSAPpointLoadType.Force_Moment;

                    snd.PointLoads.Add(pl);
                }
            }
        }
    }
}
