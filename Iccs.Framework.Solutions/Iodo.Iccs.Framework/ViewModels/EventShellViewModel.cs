using Caliburn.Micro;

/******************************************************************************
 * Abstract Class EventShellViewModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.ViewModels
{
    public abstract class EventShellViewModel<T1, T2>
        : Conductor<IScreen>.Collection.OneActive
        where T1 : IScreen
        where T2 : IScreen
    {
        #region - Ctors -
        public EventShellViewModel(
              T1 preEventListViewModel
            , T2 postEventListViewModel)
        {
            Items.Add(preEventListViewModel);
            Items.Add(postEventListViewModel);
            ActiveItem = Items[0];
        }
        #endregion

        #region - Attributes -
        #endregion
    }
}
