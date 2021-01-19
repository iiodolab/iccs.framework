using Iodo.Iccs.Framework.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

/******************************************************************************
 * Abstract class EventViewModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.ViewModels
{
    public abstract class EventViewModel 
        : NotifierPropertyChanged, IEventViewModel
    {
        #region - Ctors -
        public EventViewModel(EventModel eventModel)
        {
            EventModel = eventModel;
        }
        #endregion

        #region - Implementations for IEventViewModel -
        public Task Execute(CancellationToken tokenSourceEvent = default)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region - Properties for IEventViewModel -
        public int Id
        {
            get => EventModel.Id;
            set
            {
                EventModel.Id = value;
                OnPropertyChanged();
            }
        }

        public EventModel EventModel { get; }
        public CancellationTokenSource CancellationTokenSourceEvent { get; set; }
        #endregion

        #region - Properties -
        public string TagFault { get; set; }
        #endregion

        #region - Attriibtes -
        #endregion
    }
}
