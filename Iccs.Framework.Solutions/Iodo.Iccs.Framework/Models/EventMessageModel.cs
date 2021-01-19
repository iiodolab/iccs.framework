/******************************************************************************
 * Class EventMessageModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Models
{
    public  class EventMessageModel<T> : IEventMessageModel<T>
    {
        public T Value
        {
            get => content;
            set => content = value;
        }

        public string Command
        {
            get => command;
            set => command = value;
        }

        public virtual int CommandId
        {
            get => commandId;
            set => commandId = value;
        }

        #region - Attributes -
        protected int commandId;
        private T content;
        private string command;
        #endregion
    }
}
