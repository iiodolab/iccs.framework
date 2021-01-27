using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using Iodo.Iccs.Framework.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            CancellationTokenSourceHandler = new CancellationTokenSource();
        }
        #endregion

        #region - Abstracts -
        public void Start()
        {
            var token = CancellationTokenSourceHandler.Token;
            foreach (var service in Container.Resolve<IEnumerable<IService>>())
            {
                service.ExecuteAsync(token);
            }
        }
        public virtual void Stop()
        {
            CancellationTokenSourceHandler.Cancel();
            CancellationTokenSourceHandler.Dispose();
        }
        #endregion

        #region - Overrides -
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            try
            {
                Start();
                DisplayRootViewFor<T>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            var connection = Container.Resolve<IDbConnection>();
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }

            try
            {
                var subconn = Container.Resolve<ISubscriber>();
                if (subconn.IsConnected())
                {
                    subconn.Multiplexer.Close();
                    subconn.Multiplexer.Dispose();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            Stop();
            base.OnExit(sender, e);
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<WindowManager>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<EventAggregator>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<T>().SingleInstance();
        }
        #endregion

        #region - Procedures -
        #endregion

        #region - Properties -
        #endregion

        #region - Properties - 
        protected CancellationTokenSource CancellationTokenSourceHandler { get; }
        #endregion
    }
}
