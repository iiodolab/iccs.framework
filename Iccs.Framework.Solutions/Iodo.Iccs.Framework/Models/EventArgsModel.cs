using System;

/******************************************************************************
 * Class EventArgsModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Models
{
    public class EventArgsModel<T> : EventArgs
    {
        #region - Abstracts -
        public T Value { get; set; }
        #endregion
    }
}
