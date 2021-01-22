using Newtonsoft.Json.Linq;
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
        protected abstract void ProcessChannel1Message(object sender, ChannelMessage message);
        protected abstract void ProcessChannel2Message(object sender, ChannelMessage message);
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
