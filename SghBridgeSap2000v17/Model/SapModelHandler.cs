using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SAP2000v17;
using SghBridgeContract.DTO.Sap2000v17.Model;
using SghBridgeContract.DTO.Sap2000v17.ModelProperties;
using SghBridgeContract.Interfaces;


namespace SghBridgeSap2000v17.Model
{
    public class SapModelHandler
    {
        public void SetSAPModelInfo(IModelDTO Imodel, cSapModel sap_mo)
        {
            SapModelDTO sm = Imodel as SapModelDTO;
            sap_mo.SetPresentUnits(GetSAPUnit(sm.modelUnit));

            //add else
            
        }
        public IModelDTO GetSAPModelInfo(cSapModel sap_mo)
        {
            SapModelDTO sm = new SapModelDTO();
            sm.modelUnit = GetBridgeUnit(sap_mo);

            //add else
            
            return sm;
        }



        private SAP2000v17.eUnits GetSAPUnit(eBridgeModelUnitType model_unit)
        {
            if(model_unit == eBridgeModelUnitType.kgf_cm_C)
            {
                return eUnits.kgf_cm_C;
            }
            else if(model_unit == eBridgeModelUnitType.kgf_mm_C)
            {
                return eUnits.kgf_mm_C;
            }
            else if (model_unit == eBridgeModelUnitType.kgf_m_C)
            {
                return eUnits.kgf_m_C;
            }
            else if (model_unit == eBridgeModelUnitType.kip_ft_F)
            {
                return eUnits.kip_ft_F;
            }
            else if (model_unit == eBridgeModelUnitType.kip_in_F)
            {
                return eUnits.kip_in_F;
            }
            else if (model_unit == eBridgeModelUnitType.kN_cm_C)
            {
                return eUnits.kN_cm_C;
            }
            else if (model_unit == eBridgeModelUnitType.kN_mm_C)
            {
                return eUnits.kN_mm_C;
            }
            else if (model_unit == eBridgeModelUnitType.kN_m_C)
            {
                return eUnits.kN_m_C;
            }
            else if (model_unit == eBridgeModelUnitType.lb_ft_F)
            {
                return eUnits.lb_ft_F;
            }
            else if (model_unit == eBridgeModelUnitType.lb_in_F)
            {
                return eUnits.lb_in_F;
            }
            else if (model_unit == eBridgeModelUnitType.N_cm_C)
            {
                return eUnits.N_cm_C;
            }
            else if (model_unit == eBridgeModelUnitType.N_mm_C)
            {
                return eUnits.N_mm_C;
            }
            else if (model_unit == eBridgeModelUnitType.N_m_C)
            {
                return eUnits.N_m_C;
            }
            else if (model_unit == eBridgeModelUnitType.Ton_cm_C)
            {
                return eUnits.Ton_cm_C;
            }
            else if (model_unit == eBridgeModelUnitType.Ton_mm_C)
            {
                return eUnits.Ton_mm_C;
            }
            else
            {
                return eUnits.Ton_m_C;
            }
        }
        private eBridgeModelUnitType GetBridgeUnit(cSapModel sap_mo)
        {
            eUnits sapUnit = sap_mo.GetPresentUnits();
            if(sapUnit == eUnits.kgf_cm_C)
            {
                return eBridgeModelUnitType.kgf_cm_C;
            }
            else if(sapUnit == eUnits.kgf_mm_C)
            {
                return eBridgeModelUnitType.kgf_mm_C;
            }
            else if (sapUnit == eUnits.kgf_m_C)
            {
                return eBridgeModelUnitType.kgf_m_C;
            }
            else if (sapUnit == eUnits.kip_ft_F)
            {
                return eBridgeModelUnitType.kip_ft_F;
            }
            else if (sapUnit == eUnits.kip_in_F)
            {
                return eBridgeModelUnitType.kip_in_F;
            }
            else if (sapUnit == eUnits.kN_cm_C)
            {
                return eBridgeModelUnitType.kN_cm_C;
            }
            else if (sapUnit == eUnits.kN_mm_C)
            {
                return eBridgeModelUnitType.kN_mm_C;
            }
            else if (sapUnit == eUnits.kN_m_C)
            {
                return eBridgeModelUnitType.kN_m_C;
            }
            else if (sapUnit == eUnits.lb_ft_F)
            {
                return eBridgeModelUnitType.lb_ft_F;
            }
            else if (sapUnit == eUnits.lb_in_F)
            {
                return eBridgeModelUnitType.lb_in_F;
            }
            else if (sapUnit == eUnits.N_cm_C)
            {
                return eBridgeModelUnitType.N_cm_C;
            }
            else if (sapUnit == eUnits.N_mm_C)
            {
                return eBridgeModelUnitType.N_mm_C;
            }
            else if (sapUnit == eUnits.N_m_C)
            {
                return eBridgeModelUnitType.N_m_C;
            }
            else if (sapUnit == eUnits.Ton_cm_C)
            {
                return eBridgeModelUnitType.Ton_cm_C;
            }
            else
            {
                return eBridgeModelUnitType.Ton_mm_C;
            }
        }
    }
}
