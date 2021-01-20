using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using Iodo.Iccs.Framework.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;

/******************************************************************************
 * Class Bootstrapper
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework
{
    public abstract class Bootstrapper<T> : AutofacBootstrapper<T>
    {
        #region - Ctors -
        public Bootstrapper()
        {
            ListService = new List<IService>();
            CancellationTokenSourceApp = new CancellationTokenSource();
        }
        #endregion

        #region - Abstracts -
        protected abstract void StartUp();
        protected abstract void Stop();

        #endregion

        #region - Overrides -
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            try
            {
                var token = CancellationTokenSourceApp.Token;
                StartUp();
                ListService.ForEach((service) => service.ExecuteAsync(token));

                DisplayRootViewFor<T>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<WindowManager>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<EventAggregator>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<T>().SingleInstance();
        }
        #endregion

        #region - Procedures -
        public void AddTask(IService service)
        {
            ListService.Add(service);
        }
        #endregion

        #region - Properties -
        private List<IService> ListService { get; }
        #endregion

        #region - Properties - 
        protected CancellationTokenSource CancellationTokenSourceApp { get; }
        #endregion
    }
}
