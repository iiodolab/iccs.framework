using Newtonsoft.Json.Linq;

/******************************************************************************
 * Interface IIccsContoller
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Services
{
    internal interface IIccsContoller
    {
        void BuildLookupTabel();
        void ProcessDetection(JToken target);
        void ProcessFault(JToken target);
        void ProcessConnection(JToken target);
    }
}
