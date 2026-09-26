namespace UtilityToolkit.Structures
{
    public class CircularArray<T>
    {
        private readonly T[] _items;
        private int _headIndex;
    
        public T Head => _items[_headIndex];
        public int Length => _items.Length;
    
        public CircularArray(T head, T[] tail)
        {
            _items = new T[tail.Length + 1];
            _items[0] = head;
            tail.CopyTo(_items, 1);
        }

        public T MoveRight()
        {
            _headIndex = (_headIndex + 1) % Length;
            return _items[_headIndex];
        }

        public T MoveLeft()
        {
            _headIndex = (_headIndex - 1 + Length) % Length;
            return _items[_headIndex];
        }
    }
}