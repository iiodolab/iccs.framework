using Iodo.Iccs.Framework.Models;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

/******************************************************************************
 * Abstract Class IccsService
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/
namespace Iodo.Iccs.Framework.Services
{
    public abstract class IccsService 
        : TaskService, IIccsService
    {
        #region - Ctors -
        public IccsService(MessageService messageService)
        {
            MessageService = messageService;
        }
        #endregion

        #region - Abstracts -
        public abstract void BuildLookupTabel();
        public abstract void ProcessDetection(JToken target);
        public abstract void ProcessFault(JToken target);
        public abstract void ProcessConnection(JToken target);
        #endregion

        #region - Implementations for the TaskService's overrides -
        public override void Stop()
        {
            MessageService.Channel1EventHandler -= ProcessChannel1Message;
            MessageService.Channel2EventHandler -= ProcessChannel2Message;
        }

        protected override Task RunTask(CancellationToken token = default)
        {
            return Task.Run(() => {
                    BuildLookupTabel();
                    RegisterEventHandelers();
            });
        }

        protected virtual async void ProcessChannel1Message(object sender, ChannelMessage message)
        {
            foreach (var item in JArray.Parse(message.Message))
            {
                try
                {
                    switch ((EventType)item.Value<int>("command"))
                    {
                        case EventType.Intrusion:
                            await Task.Run(() => ProcessDetection(item));
                            break;

                        case EventType.Fault:
                            await Task.Run(() => ProcessFault(item));
                            break;

                        case EventType.Connection:
                            await Task.Run(() => ProcessConnection(item));
                            break;

                        default:
                            throw new TypeAccessException();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        protected virtual void ProcessChannel2Message(object sender, ChannelMessage message)
        {

        }
        #endregion

        #region - Procedures -
        private void RegisterEventHandelers()
        {
            MessageService.Channel1EventHandler += ProcessChannel1Message;
            MessageService.Channel2EventHandler += ProcessChannel2Message;
        }
        #endregion

        #region - Properties -
        private MessageService MessageService { get; }
        #endregion
    }
}
