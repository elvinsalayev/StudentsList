using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics.First
{
    [Serializable]
    internal class GenericStore<T> : IEnumerable<T>

    {
        T[] data = new T[0];

        public void Add(T item)
        {
            Array.Resize(ref data, data.Length + 1);

            data[data.Length - 1] = item;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= data.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return data[index];
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= data.Length || index < 0)
                return;

            for (int i = index; i < data.Length - 1; i++)
            {
                data[index] = data[index + 1];
            }

            Array.Resize(ref data, data.Length - 1);
        }

        public int Length
        {
            get
            {
                return data.Length;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
