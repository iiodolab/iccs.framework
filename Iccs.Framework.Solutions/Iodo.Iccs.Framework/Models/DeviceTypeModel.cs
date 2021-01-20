/******************************************************************************
 * Enum DeviceType
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2021.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Models
{
    public enum DeviceType : int
    {
        Controller = 1,
        Compound = 2,
        Vibration = 3,
        Underground = 4,
        Contact = 5,
        PIR = 6,
        IoController = 7,
        Laser = 8
    }
}
