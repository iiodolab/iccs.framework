﻿using Caliburn.Micro;

/******************************************************************************
 * Abstract Class CanvasEntityViewModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.ViewModels
{
    public abstract class CanvasEntityViewModel<T>
        : Screen
    {
        #region - Ctors
        public CanvasEntityViewModel(T entityProvider, bool visibility = true)
        {
            EntityProvider = entityProvider;
            Visibility = visibility;
        }
        #endregion

        #region - Properties -
        public T EntityProvider  { get; }

        public bool Visibility {
            get => visibility;
            set
            {
                visibility = value;
                NotifyOfPropertyChange(() => Visibility);
            }
        }
        #endregion

        #region - Attributes -
        private bool visibility;
        #endregion
    }
}
