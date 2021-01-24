using Iodo.Iccs.Framework.Models;
using System.Threading;
using System.Threading.Tasks;

/******************************************************************************
 * Class IEventViewModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.ViewModels
{
    public interface IEventViewModel        
    {
        #region - Interfaces -
        Task Execute(CancellationToken tokenSourceEvent);
        IEventModel EventModel { get; }
        CancellationTokenSource CancellationTokenSourceEvent { get; set; }
        #endregion
    }
}
