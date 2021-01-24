using Caliburn.Micro;
using Iodo.Iccs.Framework.Utils;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

/******************************************************************************
 * Abstract Class ShellViewModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.ViewModels
{
    public abstract class ShellViewModel 
        : Conductor<IScreen>
    {
        #region - Ctors -
        public ShellViewModel()
        {   
            EventAggregator = IoC.Get<IEventAggregator>();
            EventAggregator.Subscribe(this);
        }
        #endregion

        #region - Dtor -
        ~ShellViewModel()
        {
            EventAggregator.Unsubscribe(this);
        }
        #endregion

        #region - Event Handlers - 
        public void OnKeyDownToggleMaximize(object sender, KeyEventArgs e)
        {
            try
            {
                if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    return;

                if (e.Key != Key.F11)
                    return;

                var window = sender as Window;
                var task = window.Dispatcher.BeginInvoke(new Action<Window>(MaximizeWindow), window);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region - Procedures -
        private void MaximizeWindow(Window window)
        {
            var styleWindow = SourceChord.FluentWPF.AcrylicWindowStyle.None;

            switch (isFullScreen ^= true)
            {
                case true:
                    window.MaximizeToCurrentMonitor();
                    break;

                case false:
                default:
                    styleWindow = SourceChord.FluentWPF.AcrylicWindowStyle.Normal;
                    window.WindowState = WindowState.Normal;
                    break;
            }

            window.SetValue(SourceChord.FluentWPF.AcrylicWindow.AcrylicWindowStyleProperty, styleWindow);        
        }
        #endregion

        #region - Properties -
        protected IEventAggregator EventAggregator { get; }
        #endregion

        #region - Attributes -
        protected bool isFullScreen = default;
        #endregion
    }
}
