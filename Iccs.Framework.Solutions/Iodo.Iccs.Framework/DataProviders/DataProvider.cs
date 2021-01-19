using System.Threading;
using System.Threading.Tasks;

/******************************************************************************
 * Class Collector
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.DataProviders
{
    public abstract class DataProvider : IDataProvider
    {
        #region - Implementations for IDataProvider -
        public abstract Task ExecuteAsync(CancellationToken token = default);
        #endregion 
    }
}