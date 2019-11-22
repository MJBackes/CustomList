using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Random rng;
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
                    throw new ArgumentOutOfRangeException("Can only set Capacity to values larger than the Count of the list.");
                }
            }
        }
        public T this[int i]
        {
            get {
                if (i < count && i >= 0)
                {
                    return internalStorage[i];
                }
                else
                {
                    if (i >= count)
                    {
                        throw new IndexOutOfRangeException("Index was too large.");
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Index was too small.");
                    }
                }
            }
            set {
                if (i < count && i >= 0)
                {
                    internalStorage[i] = value;
                }
                else
                {
                    if (i >= count)
                    {
                        throw new IndexOutOfRangeException("Index was too large.");
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Index was too small.");
                    }
                }
            }
        }
        public CustomList()
        {
            capacity = 4;
            count = 0;
            internalStorage = new T[capacity];
            rng = new Random();
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
            int tempIndex = 0;
            for (int i = 0; i < count; i++)
            {
                if(tempIndex >= capacity)
                {
                    internalStorage[i] = default;
                    continue;
                }
                else if (internalStorage[tempIndex].Equals(input) && !foundObjectToBeRemoved)
                {
                    foundObjectToBeRemoved = true;
                    tempIndex++;
                    count--;
                }
                internalStorage[i] = internalStorage[tempIndex];
                tempIndex++;
            }
            return foundObjectToBeRemoved;
        }
        public int RemoveAll(T input)
        {
            int removedCount = 0;
            int tempIndex = 0;
            for (int i = 0; i < count; i++)
            {
                if (tempIndex >= capacity)
                {
                    internalStorage[i] = default;
                    continue;
                }
                else if (internalStorage[tempIndex].Equals(input))
                {
                    do
                    {
                        tempIndex++;
                        removedCount++;
                    } while (internalStorage[tempIndex].Equals(input));
                }
                internalStorage[i] = internalStorage[tempIndex];
                tempIndex++;
            }
            count -= removedCount;
            return removedCount;
        }
        public void Clear()
        {
            internalStorage = new T[capacity];
            count = 0;
        }
        public void Reverse()
        {
            T[] tempStorage = new T[capacity];
            for(int i = 0; i < count; i++)
            {
                tempStorage[i] = internalStorage[count - (i + 1)];
            }
            internalStorage = tempStorage;
        }
        public void Reverse(int start, int numberToReverse)
        {
            int finish = start + numberToReverse;
            T[] tempStorage = new T[capacity];
            for(int i = 0; i < start; i++)
            {
                tempStorage[i] = internalStorage[i];
            }
            int counter = 0;
            for (int i = start; i < finish; i++)
            {
                tempStorage[i] = internalStorage[finish - (counter + 1)];
                counter++;
            }
            for (int i = finish; i < count; i++)
            {
                tempStorage[i] = internalStorage[i];
            }
            internalStorage = tempStorage;
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
        //public T[] ToArray()
        //{
        //    T[] output = new T[Count];
        //    for (int i = 0; i < Count; i++)
        //        output[i] = internalStorage[i];
        //    return output;
        //}
        public T[] ToArray(T[] input = null,int index = 0)
        {
            if (input == null)
                input = new T[Count];
            input[index] = internalStorage[index];
            if (index == Count - 1)
                return input;
            return ToArray(input, ++index);
        }
        public bool Contains(T input,int index = 0)
        {
            if (Comparer<T>.Default.Compare(internalStorage[index], input) == 0)
                return true;
            else if (index == Count - 1)
                return false;
            else
                return Contains(input, ++index);
        }
        public bool Exists(Predicate<T> predicate,int index = 0)
        {
            if(predicate(internalStorage[index]))
                return true;
            if (index == Count - 1)
                return false;
            return Exists(predicate, ++index);
        }
        public T Find(Predicate<T> predicate,int index = 0)
        {
            if (predicate(internalStorage[index]))
                return internalStorage[index];
            else if (index == Count - 1)
                return default;
            else
                return Find(predicate, ++index);
        }
        public CustomList<T> FindAll(Predicate<T> predicate, CustomList<T> output = null, int index = 0) 
        {
            if (output == null)
                output = new CustomList<T>();
            if (predicate(internalStorage[index]))
                output.Add(internalStorage[index]);
            if (index == Count - 1)
                return output;
            else
                return FindAll(predicate, output, ++index);
        }
        public int FindIndex(Predicate<T> predicate, int index = 0)
        {
            if (predicate(internalStorage[index]))
                return index;
            else if (index == Count - 1)
                return -1;
            else
                return FindIndex(predicate, ++index);
        }
        public int FindIndex(int index,Predicate<T> predicate)
        {
            if (predicate(internalStorage[index]))
                return index;
            else if (index == Count - 1)
                return -1;
            else
                return FindIndex(++index,predicate);
        }
        public int FindIndex(int index, int stopIndex,Predicate<T> predicate)
        {
            if (predicate(internalStorage[index]))
                return index;
            else if (index == stopIndex)
                return -1;
            else
                return FindIndex(++index,stopIndex,predicate);
        }
        public int FindLastIndex(Predicate<T> predicate,int index = -1)
        {
            if (index == -1)
                index = Count - 1;
            if (predicate(internalStorage[index]))
                return index;
            if (index == 0)
                return -1;
            return FindLastIndex(predicate, --index);
        }
        public int FindLastIndex(int startingIndex, Predicate<T> predicate, int index = -1)
        {
            if (index == -1)
                index = Count - 1;
            if (predicate(internalStorage[index]))
                return index;
            if (index == startingIndex)
                return -1;
            return FindLastIndex(startingIndex, predicate, --index);
        }
        public int FindLastIndex(int startingIndex, int index, Predicate<T> predicate)
        {
            if (startingIndex > index)
                throw new ArgumentOutOfRangeException("Starting index can not be larger than the Ending index.");
            if (index == -1)
                index = Count - 1;
            if (predicate(internalStorage[index]))
                return index;
            if (index == startingIndex)
                return -1;
            return FindLastIndex(startingIndex, --index, predicate);
        }
        public ReadOnlyCollection<T> AsReadOnly()
        {
            return new ReadOnlyCollection<T>(ToArray());
        }
        public void CopyTo(T[] array, int arrayIndex = 0,int recursiveIndex = 0)
        {
            if (arrayIndex == array.Length || recursiveIndex == Count)
                return;
            array[arrayIndex] = internalStorage[recursiveIndex];
            CopyTo(array, ++arrayIndex, ++recursiveIndex);
        }
        public void CopyTo(int recursiveIndex,T[] array, int arrayIndex = 0)
        {
            if (arrayIndex == array.Length || recursiveIndex == Count)
                return;
            array[arrayIndex] = internalStorage[recursiveIndex];
            CopyTo(array, ++arrayIndex, ++recursiveIndex);
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
            CustomList<T> smallerList = GetLeftList(pivot);
            CustomList<T> largerList = GetRightList(pivot);
            smallerList.Sort();
            largerList.Sort();
            smallerList += largerList;
            CopyListContents(smallerList);
        }
        private int GetPivot()
        {
            return rng.Next(count);
        }
        private int MoveLargerElementsToTheRightOf(int index)
        {
            T[] tempList = new T[capacity];
            int tempIndex = 0;
            for(int i = 0; i < count; i++)
            {
                if(Comparer<T>.Default.Compare(internalStorage[index], internalStorage[i]) > 0 )
                {
                    tempList[tempIndex] = internalStorage[i];
                    tempIndex++;
                }
            }
            int newPivotLoction = tempIndex;
            for (int i = 0; i < count; i++)
            {
                if (Comparer<T>.Default.Compare(internalStorage[index], internalStorage[i]) < 0
                                        || Comparer<T>.Default.Compare(internalStorage[index], internalStorage[i]) == 0)
                {
                    tempList[tempIndex] = internalStorage[i];
                    tempIndex++;
                }
            }
            internalStorage = tempList;
            return newPivotLoction;
        }
        private CustomList<T> GetLeftList(int pivot)
        {
            CustomList<T> output = new CustomList<T>();
            for(int i = 0; i < pivot; i++)
            {
                output.Add(internalStorage[i]);
            }
            return output;
        }
        private CustomList<T> GetRightList(int pivot)
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
