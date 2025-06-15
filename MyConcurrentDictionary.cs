using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Informatika
{
    public class MyConcurrentDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> Dictionary = new Dictionary<TKey, TValue>();
        private readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();

        public bool TryGet(TKey key, out TValue value)
        {
            Lock.EnterReadLock();
            try
            {
                return Dictionary.TryGetValue(key, out value);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        public bool TryAdd(TKey key, TValue value)
        {
            Lock.EnterWriteLock();
            try
            {
                if (Dictionary.ContainsKey(key))
                {
                    return false;
                }
                Dictionary.Add(key, value);
                return true;
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }
        public TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
        {
            Lock.EnterWriteLock();
            try
            {
                if (Dictionary.TryGetValue(key, out var existingValue))
                {
                    TValue newValue = updateValueFactory(key, existingValue);
                    Dictionary[key] = newValue;
                    return newValue;
                }
                else
                {
                    Dictionary.Add(key, addValue);
                    return addValue;
                }
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }
        public bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue)
        {
            Lock.EnterWriteLock();
            try
            {
                if (Dictionary[key].Equals(comparisonValue))
                {
                    Dictionary[key] = newValue;
                    return true;
                }
                return false;
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }
    }
}
