using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Data;

/******************************************************************************
 * Class CollectionProvider
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.DataProviders
{
    [DebuggerDisplay("Count = {CollectionData.Count}")]
    public class CollectionProvider<T> : ICollector<T>
    {
        #region - Ctors -
        public CollectionProvider(IEnumerable<T> collection)
        {
            CollectionData = new ObservableCollection<T>(collection);
            locker = new object();
            BindingOperations.EnableCollectionSynchronization(CollectionData, locker);
        }

        public CollectionProvider()
        {
            CollectionData = new ObservableCollection<T>();
            locker = new object();
            BindingOperations.EnableCollectionSynchronization(CollectionData, locker);
        }
        #endregion

        #region - Implementations for ICollectionManager -
        public virtual void Add(T item)
        {
            lock (locker)
                CollectionData.Add(item);
        }

        public virtual void Remove(T item)
        {
            lock (locker)
                CollectionData.Remove(item);
        }

        public virtual void Clear()
        {
            lock (locker)
                CollectionData.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {   
            return CollectionData.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return CollectionData.GetEnumerator();
        }

        public int Count => CollectionData.Count;
        #endregion

        #region - Procedures -
        #endregion

        #region - Properties -
        public ObservableCollection<T> CollectionData { get; set; }
        #endregion

        #region - Attributes -
        protected readonly object locker;
        #endregion
    }
}
