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
        public static CustomList<T> operator + (CustomList<T> list1, CustomList<T> list2)
        {
            CustomList<T> output = new CustomList<T>();
            for(int i = 0; i < list1.Count; i++)
            {
                output.Add(list1[i]);
            }
            for (int i = 0; i < list2.Count; i++)
            {
                output.Add(list2[i]);
            }
            return output;
        }
        public static CustomList<T> operator -(CustomList<T> list1, CustomList<T> list2)
        {
            bool hasAppeared;
            CustomList<T> tempList2 = new CustomList<T>();
            tempList2.DuplicateList(list2);
            CustomList<T> output = new CustomList<T>();
            for (int i = 0; i < list1.Count; i++)
            {
                hasAppeared = false;
                for(int j = 0; j < tempList2.count; j++)
                {
                    if(list1[i].Equals(tempList2[j]))
                    {
                        hasAppeared = true;
                        tempList2.Remove(tempList2[j]);
                    }
                }
                if (!hasAppeared)
                {
                    output.Add(list1[i]);
                }
            }
            return output;
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
        public void DuplicateList(CustomList<T> input)
        {
            for(int i = 0; i < input.Count; i++)
            {
                Add(input[i]);
            }
        }
    }
}
