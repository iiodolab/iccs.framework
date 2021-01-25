using Caliburn.Micro;
using System.Collections.Generic;

/******************************************************************************
* Abstract Class DialogShellViewModel
* 
*                                                   author: Jinwoo Choi, PhD.
*                                                 organization: Kookmin Univ.
*                                                           date: 2020.10.28
*                                                           
*****************************************************************************/

namespace Iodo.Iccs.Framework.ViewModels
{
    public abstract class DialogShellViewModel
        : Conductor<IScreen>.Collection.OneActive
    {
        public DialogShellViewModel(IEnumerable<IScreen> enumerator)
        {
            foreach (var item in enumerator)
            {
                Items.Add(item);
            }
        }
    }
}
