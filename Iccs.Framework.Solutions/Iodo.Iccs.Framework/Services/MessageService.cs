using StackExchange.Redis;
using System;
using System.Threading;
using System.Threading.Tasks;

/******************************************************************************
 * Abstract Class MessageService
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Services
{
    public abstract class MessageService 
        : TaskService
    {
        #region - Ctors -
        public MessageService(ISubscriber subscriber, string nameChannel)
        {
            Subscriber = subscriber;
            NameChannel = nameChannel;
        }
        #endregion

        #region - Implements asbtracts -
        protected override async Task RunTask(CancellationToken token = default)
        {
            await Task.Run(delegate { RegisterSubscribers(); }, token);
        }

        public override void Stop()
        {
        }
        #endregion
        #region - Procedures -
        protected virtual void RegisterSubscribers()
        {  
           Subscriber.Subscribe(NameChannel).OnMessage((message) =>
                    Channel1EventHandler?.Invoke(this, message));
        }
        #endregion

        #region - Properties -
        protected ISubscriber Subscriber { get; }
        private string NameChannel { get; }
        #endregion

        #region - Delegators for EventHandlers -
        public event EventHandler<ChannelMessage> Channel1EventHandler;
        public event EventHandler<ChannelMessage> Channel2EventHandler;
        #endregion
    }
}
