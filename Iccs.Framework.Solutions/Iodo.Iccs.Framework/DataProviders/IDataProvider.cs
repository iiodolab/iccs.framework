using System.Threading;
using System.Threading.Tasks;

/******************************************************************************
 * Interface IDataProvider
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.DataProviders
{
    public interface IDataProvider
    {
        Task ExecuteAsync(CancellationToken token = default);
    }
}
