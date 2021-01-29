using Iodo.Iccs.Framework.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Data;

/******************************************************************************
 * Class EntityCollectionProvider
 * 
 *                                                   author: Jinwoo Choi, PhD.
 *                                                 organization: Kookmin Univ.
 *                                                           date: 2020.10.28
 *                                                           
 *****************************************************************************/

namespace Iodo.Iccs.Framework.DataProviders
{
    [DebuggerDisplay("Count = {CollectionEntity.Count}")]
    public abstract class EntityCollectionProvider<T>        
        : ICollector<T>
        where T : IEntityViewModel
    {
        #region - Ctors -
        public EntityCollectionProvider(IEnumerable<T> collection)
        {
            CollectionEntity = new ObservableCollection<T>(collection);
            locker = new object();
            BindingOperations.EnableCollectionSynchronization(CollectionEntity, locker);
        }

        public EntityCollectionProvider()
        {
            CollectionEntity = new ObservableCollection<T>();
            locker = new object();
            BindingOperations.EnableCollectionSynchronization(CollectionEntity, locker);
        }
        #endregion

        #region - Implementations for ICollectionManager -
        public virtual void Add(T item)
        {
            lock (locker)
                CollectionEntity.Add(item);
        }

        public virtual void Remove(T item)
        {
            lock (locker)
                CollectionEntity.Remove(item);
        }

        public virtual void Clear()
        {
            lock (locker)
                CollectionEntity.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {   
            return CollectionEntity.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return CollectionEntity.GetEnumerator();
        }

        public int Count => CollectionEntity.Count;
        #endregion

        #region - Procedures -
        #endregion

        #region - Properties -
        public ObservableCollection<T> CollectionEntity { get; set; }
        #endregion

        #region - Attributes -
        protected readonly object locker;
        #endregion
    }
}
