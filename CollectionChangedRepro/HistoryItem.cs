namespace CollectionChangedRepro
{
    using System;

    public class HistoryItem<T>
    {
        public HistoryItem(T value)
        {
            Timestamp = DateTime.UtcNow;
            Value = value;
        }
        public DateTime Timestamp { get; private set; }
        public T Value { get; private set; }
    }
}