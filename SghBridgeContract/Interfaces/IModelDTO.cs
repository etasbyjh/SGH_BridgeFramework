using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SghBridgeContract.Interfaces
{
    public interface IModelDTO
    {
        eBridgeModelUnitType modelUnit { get; set; }
    }

    public enum eBridgeModelUnitType
    {
        kgf_cm_C,
        kgf_mm_C,
        kgf_m_C,
        kip_ft_F,
        kip_in_F,
        kN_cm_C,
        kN_mm_C,
        kN_m_C,
        lb_ft_F,
        lb_in_F,
        N_cm_C,
        N_mm_C,
        N_m_C,
        Ton_cm_C,
        Ton_mm_C
    }
}
