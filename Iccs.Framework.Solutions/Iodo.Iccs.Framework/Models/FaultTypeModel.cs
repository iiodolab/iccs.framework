/******************************************************************************
 * Enum FaultType
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2021.01.15
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.SkInno.Models
{
    public enum FaultType : int
    {
        FaultController = 1,
        FaultVibration = 2,
        FaultCompound = 3,
        FaultCable = 4,
    }
}
