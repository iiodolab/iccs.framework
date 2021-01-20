/******************************************************************************
 * Enum EventType
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2021.01.15
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.SkInno.Models
{
    public enum EventType : int
    {
        // 침입 (90: 0x5A)
        Intrusion = 0x5A,
        // 연결보고
        Connection = 0x68,
        // 조치보고 (192: 0xC0)        
        Action = 0xC0,
        // 장애보고 (115: 0x73)
        Fault = 0x73,
        // 풍량모드 (118: 0x76)
        WindyMode = 0x76
    }
}
