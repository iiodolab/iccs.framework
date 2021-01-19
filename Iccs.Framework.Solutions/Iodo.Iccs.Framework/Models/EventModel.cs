using System;

/******************************************************************************
 * Abstract class IEventModel
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.Models
{
    public abstract class EventModel 
        : IEventModel
    {
        #region - Implementations for IEventModel - 
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        #endregion
    }
}
