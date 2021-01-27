using Newtonsoft.Json.Linq;

/******************************************************************************
 * Interface IIccsService
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Services
{
    public interface IIccsService 
        : IService
    {
        void BuildLookupTabel();
        void ProcessDetection(JToken target);
        void ProcessFault(JToken target);
        void ProcessConnection(JToken target);
    }
}
