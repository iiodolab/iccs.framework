using System.Threading;
using System.Threading.Tasks;

/******************************************************************************
 * Interface IService
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Services
{
    public interface IService
    {   
        Task ExecuteAsync(CancellationToken token = default);
        void Stop();
    }
}
