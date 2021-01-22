/******************************************************************************
 * Enum FaultType
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Models
{
    public enum FaultType : int
    {
        FaultController = 1,
        FaultVibration = 2,
        FaultCompound = 3,
        FaultCable = 4,
    }
}
