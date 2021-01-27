using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using Iodo.Iccs.Framework.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

/******************************************************************************
 * Abstract Class Bootstrapper
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework
{
    public abstract class Bootstrapper<T> : AutofacBootstrapper<T>, IBootstrapper
    {
        #region - Ctors -
        public Bootstrapper()
        {
            ListService = new List<IService>();
            CancellationTokenSourceHandler = new CancellationTokenSource();
        }
        #endregion

        #region - Abstracts -
        public virtual void StartUp()
        {
            var token = CancellationTokenSourceHandler.Token;
            ListService.ForEach((service) => service.ExecuteAsync(token));
        }
        public virtual void Stop()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region - Overrides -
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            try
            {   
                StartUp();
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
        public void AddService(IService service)
        {
            ListService.Add(service);
        }
        #endregion

        #region - Properties -
        private List<IService> ListService { get; }
        #endregion

        #region - Properties - 
        protected CancellationTokenSource CancellationTokenSourceHandler { get; }
        #endregion
    }
}
