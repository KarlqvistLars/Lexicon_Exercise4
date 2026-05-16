namespace Exercise4_Garage_2.Interfaces
{
    public interface IGarage<T> : IEnumerable<T> where T : Vehicle
    {
        T FindByRegNumber(string uuid);
        public int Capacity { get; }
        bool IsFull { get; }
        public T this[int index] { get; set; }
        int Count { get; }
        bool IsReadOnly { get; }
        void Add(T item);
        void Clear();
        bool Contains(T item);
        void CopyTo(T[] array, int arrayIndex);
        IEnumerator<T> GetEnumerator();
        int IndexOf(T item);
        void Insert(int index, T item);
        bool Remove(T item);
    }
}
