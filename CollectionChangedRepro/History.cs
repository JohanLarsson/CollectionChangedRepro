namespace CollectionChangedRepro
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net.Mime;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Threading;

    public class History<T> : IEnumerable<HistoryItem<T>>, INotifyCollectionChanged
    {
        private readonly ConcurrentStack<HistoryItem<T>> _stack = new ConcurrentStack<HistoryItem<T>>();
        private readonly object _lock = new object();
        public History()
        {
            BindingOperations.EnableCollectionSynchronization(_stack, _lock);
        }
        public void Push(T item)
        {
            _stack.Push(new HistoryItem<T>(item));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }
        public IEnumerator<HistoryItem<T>> GetEnumerator()
        {
            return _stack.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handler = CollectionChanged;
            if (handler != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() => handler(this, e)));
                }
                else
                {
                    handler(this, e);
                }
            }
        }
    }
}
