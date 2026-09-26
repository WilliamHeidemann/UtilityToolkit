namespace UtilityToolkit.Structures
{
    public class CircularArray<T>
    {
        private readonly T[] _items;
        private int _headIndex;
        private int _length;
    
        public T Head => _items[_headIndex];
        public int Length => _length;
    
        public CircularArray(T head, T[] tail)
        {
            _length = 1 + tail.Length;
            _items = new T[_length];
            _items[0] = head;
            tail.CopyTo(_items, 1);
        }

        public T MoveRight()
        {
            _headIndex++;
            if (_headIndex == _length)
            {
                _headIndex = 0;
            }
            
            return _items[_headIndex];
        }

        public T MoveLeft()
        {
            _headIndex--;
            if (_headIndex < 0)
            {
                _headIndex = _length - 1;
            }
            
            return _items[_headIndex];
        }
    }
}