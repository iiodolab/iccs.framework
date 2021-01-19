using Iodo.Iccs.Framework.Models;
using Iodo.Iccs.Framework.ViewModels;
using System;

/******************************************************************************
 * Static Class SymbolViewModelFactory
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.DataProviders
{
    public static class SymbolViewModelFactory
    {
        #region - Static Procedures -
        public static T Build<T>(ISymbolModel model) where T : SymbolViewModel, new()
        {
            var viewModel = (T)Activator.CreateInstance(typeof(T), new object[] { model });
            return viewModel;
        }
        #endregion
    }
}
