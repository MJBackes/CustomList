using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomList
{
    public class CustomList<T> : IEnumerable
    {
        private T[] internalStorage;
        private int count;
        private int capacity;
        public int Count { get => count; }
        public int Capacity
        {
            get => capacity;
            set
            {
                if (value > count)
                {
                    capacity = value;
                    internalStorage = SetStorageSize(internalStorage, capacity);
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Can only set Capacity to values larger than the Count of the list.");
                }
            }
        }
        public T this[int i]
        {
            get {
                if (i < count)
                {
                    return internalStorage[i];
                }
                else
                {
                    if (i >= count)
                    {
                        throw new IndexOutOfRangeException($"Index was too large.");
                    }
                    else
                    {
                        throw new IndexOutOfRangeException($"Index was too small.");
                    }
                }
            }
            set {
                if (i < count)
                {
                    internalStorage[i] = value;
                }
                else
                {
                    if (i >= count)
                    {
                        throw new IndexOutOfRangeException($"Index was too large.");
                    }
                    else
                    {
                        throw new IndexOutOfRangeException($"Index was too small.");
                    }
                }
            }
        }
        public CustomList()
        {
            capacity = 4;
            count = 0;
            internalStorage = new T[capacity];
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return internalStorage[i];
            }
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
            T[] tempStorage = new T[capacity];
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
        public static CustomList<T> Zip(CustomList<T> list1, CustomList<T> list2)
        {
            int maxLength = GetLongestList(list1, list2).Count;
            CustomList<T> output = new CustomList<T>();
            for(int i = 0; i < maxLength; i++)
            {
                if (i < list1.Count)
                {
                    output.Add(list1[i]);
                }
                if (i < list2.Count)
                {
                    output.Add(list2[i]);
                }
            }
            return output;
        }
        public void Sort()
        {
            if (Count <= 16)
            {
                InsertionSort();
            }
            else
            {
                QuickSort();
            }
        }
        private void InsertionSort()
        {

            for(int i = 1; i < count; i++)
            {
                int index = i;
                while(index > 0)
                {
                    if(Comparer<T>.Default.Compare(internalStorage[index], internalStorage[index - 1]) < 0)
                    {
                        Swap(index, index - 1);
                        index--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        private void QuickSort()
        {
            int pivot = GetPivot();
            pivot = MoveLargerElementsToTheRightOf(pivot);
            CustomList<T> smallerList = GetSmallerList(pivot);
            CustomList<T> largerList = GetLargerList(pivot);
            smallerList.Sort();
            largerList.Sort();
            CustomList<T> output = smallerList + largerList;
            CopyListContents(output);
        }
        private int GetPivot()
        {
            if(Count < 3)
            {
                return 0;
            }
            CustomList<T> MedianFinder = new CustomList<T> { internalStorage[0], internalStorage[Count / 2], internalStorage[Count - 1] };
            MedianFinder.InsertionSort();
            if (EqualityComparer<T>.Default.Equals(internalStorage[0], MedianFinder[1])){
                return 0;
            }
            else if (EqualityComparer<T>.Default.Equals(internalStorage[Count/2], MedianFinder[1])){
                return Count/2;
            }
            else
            {
                return Count - 1;
            }
        }
        private int MoveLargerElementsToTheRightOf(int index)
        {
            T[] tempList = new T[capacity];
            int tempIndex = 0;
            for(int i = 0; i < count; i++)
            {
                if(Comparer<T>.Default.Compare(internalStorage[index], internalStorage[i]) > 0 
                    || Comparer<T>.Default.Compare(internalStorage[index], internalStorage[i]) == 0)
                {
                    tempList[tempIndex] = internalStorage[i];
                    tempIndex++;
                }
            }
            tempList[tempIndex] = internalStorage[index];
            int newPivotLoction = tempIndex;
            tempIndex++;
            for (int i = 0; i < count; i++)
            {
                if (Comparer<T>.Default.Compare(internalStorage[index], internalStorage[i]) < 0)
                {
                    tempList[tempIndex] = internalStorage[i];
                    tempIndex++;
                }
            }
            internalStorage = tempList;
            return newPivotLoction;
        }
        private CustomList<T> GetSmallerList(int pivot)
        {
            CustomList<T> output = new CustomList<T>();
            for(int i = 0; i < pivot; i++)
            {
                output.Add(internalStorage[i]);
            }
            return output;
        }
        private CustomList<T> GetLargerList(int pivot)
        {
            CustomList<T> output = new CustomList<T>();
            for (int i = pivot; i < Count; i++)
            {
                output.Add(internalStorage[i]);
            }
            return output;
        }
        private static CustomList<T> GetLongestList(CustomList<T> list1, CustomList<T> list2)
        {
            if(list1.Count >= list2.Count)
            {
                return list1;
            }
            else
            {
                return list2;
            }
        }
        private T[] DoubleStorageSize(T[] input)
        {
            capacity *= 2;
            T[] tempStorage = new T[capacity];
            CopyOneArrayOntoAnother(input, tempStorage);
            return tempStorage;
        }
        private T[] SetStorageSize(T[] input, int size)
        {
            T[] tempStorage = new T[size];
            CopyOneArrayOntoAnother(input, tempStorage);
            return tempStorage;
        }
        private void CopyOneArrayOntoAnother(T[] smallArray, T[] largeArray)
        {
            for(int i = 0; i < smallArray.Length; i++) {
                largeArray[i] = smallArray[i];
            }
        }
        public void Swap(int index1, int index2)
        {
            T temporaryStorage = internalStorage[index1];
            internalStorage[index1] = internalStorage[index2];
            internalStorage[index2] = temporaryStorage;
        }
        public void DuplicateList(CustomList<T> input)
        {
            for(int i = 0; i < input.Count; i++)
            {
                Add(input[i]);
            }
        }
        private void CopyListContents(CustomList<T> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                internalStorage[i] = input[i];
            }
        }
    }
}
