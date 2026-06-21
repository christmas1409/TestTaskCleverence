using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestTaskCleverence
{
    /// <summary>
    /// Потокобезопасный счетчик с разделением на читателей/писателей
    /// </summary>
    public class ThreadSafeCounter
    {
        private int _count = 0;
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        /// <summary>
        /// Получить текущее значение
        /// </summary>
        public int GetCount()
        {
            _lock.EnterReadLock();
            try
            {
                return _count;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        /// <summary>
        /// Добавить значение
        /// </summary>
        public void AddToCount(int value)
        {
            _lock.EnterWriteLock();
            try
            {
                _count += value;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Сбросить счетчик (опционально)
        /// </summary>
        public void Reset()
        {
            _lock.EnterWriteLock();
            try
            {
                _count = 0;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}
