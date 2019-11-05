using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomList
{
    public class CustomList<T>
    {
        private T[] internalStorage;
        private int count;
        private int capacity;
        public int Count { get => count; }
        public int Capacity { get => capacity; }
        public T this[int i]
        {
            get => internalStorage[i];
            set => internalStorage[i] = value;
        }
        public CustomList()
        {
            capacity = 4;
            count = 0;
            internalStorage = new T[capacity];
        }
        public void Add(T input)
        {
            if(capacity == count)
            {
                internalStorage = DoubleStorageSize(internalStorage);
            }
            internalStorage[count] = input;
            count++;
        }
        public bool Remove(T input)
        {
            bool foundObjectToBeRemoved = false;
            T[] tempStorage = new T[internalStorage.Length];
            int tempIndex = 0;
            for (int i = 0; i < count; i++)
            {
                if (internalStorage[i].Equals(input) && !foundObjectToBeRemoved)
                {
                    foundObjectToBeRemoved = true;
                }
                else
                {
                    tempStorage[tempIndex] = internalStorage[i];
                    tempIndex++;
                }
            }
            internalStorage = tempStorage;
            count--;
            return foundObjectToBeRemoved;
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < count; i++)
            {
                output.Append(internalStorage[i].ToString());
            }
            return output.ToString();
        }
        private T[] DoubleStorageSize(T[] input)
        {
            capacity *= 2;
            T[] tempStorage = new T[capacity];
            CopyOneArrayOntoAnother(input, tempStorage);
            return tempStorage;
        }
        private void CopyOneArrayOntoAnother(T[] smallArray, T[] largeArray)
        {
            for(int i = 0; i < smallArray.Length; i++) {
                largeArray[i] = smallArray[i];
            }
        }
    }
}
