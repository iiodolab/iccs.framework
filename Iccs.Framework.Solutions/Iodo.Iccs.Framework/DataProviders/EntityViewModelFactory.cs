using Iodo.Iccs.Framework.Models;
using Iodo.Iccs.Framework.ViewModels;
using System;

/******************************************************************************
 * Static Class EntityViewModelFactory
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.DataProviders
{
    public static class EntityViewModelFactory
    {
        #region - Static Procedures -
        public static T Build<T>(IEntityModel model) where T : EntityViewModel, new()
        {
            var viewModel = (T)Activator.CreateInstance(typeof(T), new object[] { model });
            return viewModel;
        }
        #endregion
    }
}
