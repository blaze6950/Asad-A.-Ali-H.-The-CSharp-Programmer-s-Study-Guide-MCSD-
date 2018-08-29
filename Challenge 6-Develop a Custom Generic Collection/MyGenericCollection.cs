using System;
using System.Collections;
using System.Collections.Generic;

namespace Challenge_6_Develop_a_Custom_Generic_Collection
{
    public class MyGenericCollection<T> : IList<T>
    {
        private T[] _collection;
        private int _count = -1; // реальное кол-во элементов
        private int _capacity; // вместимость

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (_collection != null && _capacity - _count > 0)
            {
                _collection[_count] = item;
                _count++;
            }
            else if (_collection != null)
            {
                _capacity += 2;
                T[] newCollection = new T[_capacity];
                int i = 0;
                foreach (var oldItem in _collection)
                {
                    newCollection[i] = oldItem;
                    i++;
                }
                newCollection[_count] = item;
                _collection = newCollection;
                _count++;
            }
            else
            {
                _capacity += 2;
                _count = 1;
                _collection = new T[_capacity];
                _collection[0] = item;
            }
        }

        public void Clear()
        {
            _collection = null;
            _count = -1;
            _capacity = 0;
        }

        public bool Contains(T item)
        {
            foreach (var oldItem in _collection)
            {
                if (oldItem.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("array");
            }
            if (array.Rank > 0 || array.Length - arrayIndex < _collection.Length)
            {
                throw new ArgumentException("array is multidimensional or not enough space");
            }
            // ReSharper disable once IsExpressionAlwaysTrue
            if (!(array[0] is T))
            {
                throw new ArrayTypeMismatchException();
            }
            if (_collection.Rank > 0)
            {
                throw new RankException();
            }

            for (int i = arrayIndex, j = 0; i < _count; i++, j++)
            {
                array[i] = _collection[j];
            }
        }

        public bool Remove(T item)
        {
            int count = _count;
            RemoveAt(IndexOf(item));
            if (_count == count - 1)
            {
                return true;
            }
            return false;
        }

        public int Count { get => _count; }
        public bool IsReadOnly { get => _collection.IsReadOnly; }
        public int IndexOf(T item)
        {
            int i = 0;
            foreach (var oldItem in _collection)
            {
                if (oldItem.Equals(item))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (_collection != null && _capacity - _count > 0)
            {
                for (int i = _count; i >= index; i--)
                {
                    if (i == index)
                    {
                        _collection[i] = item;
                        break;
                    }
                    _collection[i] = _collection[i - 1];
                }
                _count++;
            }
            else if (_collection != null)
            {
                T[] newCollection = new T[_count + 1];
                int i = 0;
                foreach (var el in _collection)
                {
                    if (i == index)
                    {
                        newCollection[i] = item;
                        i++;
                    }
                    newCollection[i] = el;
                    i++;
                }
                _collection = newCollection;
                _count++;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void RemoveAt(int index)
        {
            if (_collection != null && _count > index && index > 0)
            {
                for (int i = index; i < _count; i++)
                {
                    if (i + 1 < _capacity)
                    {
                        _collection[i] = _collection[i + 1];
                    }
                }
                _count--;
            }
            else
            {
                if (_collection != null)
                    throw new IndexOutOfRangeException();
                else
                    throw new ArgumentNullException();
            }
        }

        public T this[int index]
        {
            get
            {
                if (index > _count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _collection[index];
            }

            set
            {
                if (index > _count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _collection[index] = value;
            }
        }

    }

    internal class Enumerator<T> : IEnumerator<T>
    {
        MyGenericCollection<T> _genericCollection;
        private int _current;
        public Enumerator(MyGenericCollection<T> ngenericCollection)
        {
            _genericCollection = ngenericCollection;
            _current = -1;
        }


        public bool MoveNext()
        {
            var result = _genericCollection.Count > ++_current;
            return result;
        }

        public void Reset()
        {
            _current = -1;
        }

        public T Current => _genericCollection[_current];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _genericCollection = null;
            _current = -1;
        }
    }
}