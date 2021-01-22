using StackExchange.Redis;
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
    public abstract class IccsService : TaskService
    {
        #region - Ctors -
        public IccsService(MessageService messageService)
        {
            MessageService = messageService;
        }
        #endregion

        #region - Abstrahcts -
        //protected abstract void ProcessChannel1Message(object sender, ChannelMessage message);
        //protected abstract void ProcessChannel2Message(object sender, ChannelMessage message);
        protected abstract void BuildLookup();
        #endregion

        #region - Implementations for the TaskService's overrides -
        protected override Task RunTask(CancellationToken token = default)
        {            
            return Task.Run(delegate { RegisterEventHandelers(); });
        }

        public override void Stop()
        {
            MessageService.Channel1EventHandler -= ProcessChannel1Message;
            MessageService.Channel2EventHandler -= ProcessChannel2Message;
        }
        #endregion

        #region - Virtuals -
        protected virtual async void ProcessChannel1Message(object sender, ChannelMessage message)
        {
            try
            {
                await Task.Run(() =>
                {
                    var jarray = JArray.Parse(message.Message);

                    foreach (var item in jarray)
                    {
                        try
                        {
                            switch ((EventType)item.Value<int>("command"))
                            {
                                case EventType.Intrusion:
                                    {
                                        var target = item.ToObject<BrkDectection>();
                                        Task.Run(() => ProcessIntrusion(target));
                                        break;
                                    }

                                case EventType.Fault:
                                    {
                                        var target = item.ToObject<BrkMalfunction>();
                                        Task.Run(() => ProcessFault(target));
                                        break;
                                    }

                                case EventType.Connection:
                                    {
                                        var target = item.ToObject<BrkConnection>();
                                        Task.Run(() => ProcessConnection(target));
                                        break;
                                    }

                                default:
                                    throw new TypeAccessException();
                            }
                        }
                        catch (Exception ex)
                        {   
                        }
                    }
                }, CancellationTokenSourceService.Token);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        protected virtual void ProcessChannel2Message(object sender, ChannelMessage message)
        {
        }


        #region - Procedures -
        private void RegisterEventHandelers()
        {
            BuildLookup();

            MessageService.Channel1EventHandler += ProcessChannel1Message;
            MessageService.Channel2EventHandler += ProcessChannel2Message;
        }
        #endregion

        #region - Properties -
        private MessageService MessageService { get; }
        #endregion
    }
}
