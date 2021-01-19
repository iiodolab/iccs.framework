using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

/******************************************************************************
 * Abstract class TaskService
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Services
{
    public abstract class TaskService : IService
    {
        #region - Abstracts -
        protected abstract Task RunTask(CancellationToken token = default);
        public abstract void Stop();
        #endregion

        #region - Implementations for IService -
        public virtual async Task ExecuteAsync(CancellationToken token = default)
        {
            try
            {
                await RunTask(token);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
