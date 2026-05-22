using Exercise4_Garage_2b.MenuClasses;
using System.Collections;

namespace Exercise4_Garage_2b {
    public class Garage<T> : IEnumerable<T> where T : IVehicle {
        private List<T> _vehicles = new();
        private int _capacity = 10;
        internal readonly IVehicle[] Vehicles;

        public Garage(int capacity) {
            _capacity = capacity;
        }
        public int Capacity => _capacity;
        public bool IsFull => _vehicles.Count >= _capacity;
        public T FindByRegNumber(string uuid) {
            return _vehicles.Find(v => v.Uuid == uuid);
        }
        // IList implementation
        public T this[int index] {
            get => _vehicles[index];
            set => _vehicles[index] = value;
        }
        public int Count => _vehicles.Count;
        public bool IsReadOnly => false;
        public bool Add(T item) {
            if (IsFull) {
                Console.WriteLine($"{Utilities.Cap(Text.Garage)} {Text.IsFull}.");
                item.ToString2();
                return false;
            }
            _vehicles.Add(item);
            return true;
        }
        public void Clear() => _vehicles.Clear();
        public bool Contains(T item) => _vehicles.Contains(item);
        public void CopyTo(T[] array, int arrayIndex)
            => _vehicles.CopyTo(array, arrayIndex);
        public IEnumerator<T> GetEnumerator()
            => _vehicles.GetEnumerator();
        public int IndexOf(T item)
            => _vehicles.IndexOf(item);
        public void Insert(int index, T item)
            => _vehicles.Insert(index, item);
        public bool Remove(T item)
            => _vehicles.Remove(item);
        public void RemoveAt(int index)
            => _vehicles.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}