using System;
using System.Collections.Generic;
using System.Text;

namespace OcclusionShared.Util
{
    /// <summary>
    /// This class is actually from https://codereview.stackexchange.com/questions/62033/creating-a-thread-safe-list-using-a-lock-object
    /// 
    /// ..except I also implemented some of the changes suggested in the accepted answer.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConcurrentList<T> : IList<T>
    {
        private List<T> internalList;

        private readonly object lockList = new object();

        public ConcurrentList()
        {
            internalList = new List<T>();
        }

        // Other Elements of IList implementation

        public IEnumerator<T> GetEnumerator()
        {
            return Clone().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Clone().GetEnumerator();
        }

        public List<T> Clone()
        {
            lock (lockList)
            {
                return new List<T>(internalList);
            }
        }

        public void Add(T item)
        {
            lock (lockList)
            {
                internalList.Add(item);
            }
        }

        public bool Remove(T item)
        {
            lock (lockList)
            {
                return internalList.Remove(item);
            }
        }

        public void Clear()
        {
            lock (lockList)
            {
                internalList.Clear();
            }
        }

        public bool Contains(T item)
        {
            lock (lockList)
            {
                return internalList.Contains(item);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (lockList)
            {
                internalList.CopyTo(array, arrayIndex);
            }
        }

        public int Count
        {
            get
            {
                lock (lockList)
                {
                    return internalList.Count;
                }
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int IndexOf(T item)
        {
            lock (lockList)
            {
                return internalList.IndexOf(item);
            }
        }

        public void Insert(int index, T item)
        {
            lock (lockList)
            {
                internalList.Insert(index, item);
            }
        }

        public void RemoveAt(int index)
        {
            lock (lockList)
            {
                internalList.RemoveAt(index);
            }
        }

        public T this[int index]
        {
            get
            {
                lock (lockList)
                {
                    return internalList[index];
                }
            }
            set
            {
                lock (lockList)
                {
                    internalList[index] = value;
                }
            }
        }
    }
}
