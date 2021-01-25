using Caliburn.Micro;
using MaterialDesignThemes.Wpf;
using System;
using System.Diagnostics;
using System.Windows;

/******************************************************************************
 * Interface DialogViewModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.ViewModels
{
    public abstract class DialogViewModel : Screen, IDialogViewModel
    {
        public abstract void Accept(IDialogVisitor visitor);

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);

            var viewer = view as FrameworkElement;
            viewer.MouseDown += (sender, e) =>
            {
                try
                {
                    var view = sender as FrameworkElement;
                    var dialog = view.FindName("DialogHost") as DialogHost;
                    var panel = view.FindName("CardContents") as FrameworkElement;

                    if (dialog.IsOpen)
                        throw new ArgumentException();

                    if (panel.IsMouseOver)
                        throw new ArgumentException();

                    IsVisible = false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            };
        }

        



        #region - Implementations for IMenuPanel - 
        public bool IsVisible
        {
            get => isVisible;
            set
            {
                isVisible = value;
                NotifyOfPropertyChange(() => IsVisible);
            }
        }
        #endregion

        #region - Attriutes - 
        protected bool isVisible;
        #endregion
    }
}
