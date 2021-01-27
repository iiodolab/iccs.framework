/******************************************************************************
 * Enum EventType
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *
 * Description
 *  침입 (90)
 *      - Intrusion = 0x5A
 *  연결보고
 *      - Connection = 0x68
 *  조치보고 (192)        
 *      - Action = 0xC0
 *  장애보고 (115)
 *      - Fault = 0x73
 *  풍량모드 (118)
 *      - WindyMode = 0x76
 *  
 *****************************************************************************/

using System.ComponentModel;

namespace Iodo.Iccs.Framework.Models
{
    public enum EventType : int
    {   
        Intrusion = 0x5A,
        Connection = 0x68,
        Action = 0xC0,
        Fault = 0x73,
        WindyMode = 0x76
    }
}
