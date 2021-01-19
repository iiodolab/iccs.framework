using System.Collections.Generic;

/******************************************************************************
 * Interface ICollector
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.DataProviders
{
    interface ICollector<T> : IEnumerable<T>
    {
        public void Add(T item);
        public void Remove(T item);
        public int Count { get; }
        public void Clear();
    }
}
