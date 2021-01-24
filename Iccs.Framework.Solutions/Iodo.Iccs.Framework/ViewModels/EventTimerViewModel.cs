using Iodo.Iccs.Framework.Models;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

/******************************************************************************
 * Class EventTimerViewModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.ViewModels
{
    public abstract class EventTimerViewModel
        : NotifierPropertyChanged, IEventViewModel
    {
        #region - Ctors - 
        public EventTimerViewModel(IEventModel eventModel)
        {
            EventModel = eventModel;
        }
        #endregion

        #region - Abstracts - 
        public abstract Task TaskFinal();
        #endregion

        #region - Implemenations for IEventViewModel - 
        public async Task Execute(CancellationToken tokenSourceEvent = default)
        {
            try
            {
                await Task.Run(async () =>
                {
                    if (tokenSourceEvent.IsCancellationRequested)
                        tokenSourceEvent.ThrowIfCancellationRequested();

                    TimeSpan ts = (TimeDiscardSec < 0) ?
                                    Timeout.InfiniteTimeSpan : TimeSpan.FromSeconds(TimeDiscardSec);
                    await Task.Delay(ts, tokenSourceEvent);

                    if (tokenSourceEvent.IsCancellationRequested)
                        tokenSourceEvent.ThrowIfCancellationRequested();

                    await TaskFinal();
                }, tokenSourceEvent);
            }
            catch (OperationCanceledException ex)
            {
                Debug.WriteLine($"TimerTask: {ex.Message}");
            }
            finally
            {
            }
        }
        #endregion

        #region - Procedures -
        [Obsolete("Execute(int timeDiscardSec, CancellationTokenSource tokenSourceEvent = default) is deprecated, Don't use it.", true)]
        public async Task Execute(int timeDiscardSec, CancellationTokenSource tokenSourceEvent = default)
        {
            TimeDiscardSec = timeDiscardSec;
            CancellationTokenSourceEvent = tokenSourceEvent;
            await Execute(CancellationTokenSourceEvent.Token);
        }

        public void Cancel()
        {
            try
            {
                CancellationTokenSourceEvent?.Cancel();
                CancellationTokenSourceEvent?.Dispose();

                EventHandlerTimer?.Invoke(this, null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion 

        #region - Properties for IEventViewModel -
        public int Id {
            get => EventModel.Id;
            set
            {
                EventModel.Id = value;
                OnPropertyChanged();
            }
        }
        public IEventModel EventModel { get; }
        public CancellationTokenSource CancellationTokenSourceEvent { get; set; }
        #endregion

        #region - Properties -
        public string Tag { get; set; }
        public string TagFault { get; set; }
        public int TimeDiscardSec { get; set; }
        public event EventHandler EventHandlerTimer;
        #endregion

        #region - Attriibtes -
        #endregion
    }
}
