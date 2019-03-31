using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }


        public void MakeArray(int new_capacity)
        {
            if (array != null)
            {
                if (new_capacity < 16) new_capacity = 16;
                capacity = new_capacity;

                T[] temp_array = new T[capacity];
                Array.Copy(array, 0, temp_array, 0, count);
                array = temp_array;
            }
            else
            {
                array = new T[new_capacity];
                capacity = new_capacity;
            }
        }


        public T GetItem(int index)
        {
            try
            {
                return array[index];
            }
            catch (IndexOutOfRangeException) { }
            return default(T);
        }


        public void Append(T itm)
        {
            try
            {
                if (count == array.Length) MakeArray(array.Length * 2);
                array[count] = itm;
                count++;
            }
            catch (IndexOutOfRangeException) { }
        }


        public void Insert(T itm, int index)
        {
            try
            {
                if (index > count) return;
                if (index < 0 || index >= capacity)
                {
                    if (index == count)
                    {
                        if (index == capacity) MakeArray(capacity * 2);
                        Append(itm);
                        return;
                    }
                    throw new IndexOutOfRangeException();
                }
                if (index == count) { Append(itm); return; }
                
                T[] temp_array = array;
                if (count == capacity) MakeArray(capacity * 2);

                for (int i = count; i >= index; i--)
                {
                    if (i == index) array[i] = itm;
                    else array[i] = temp_array[i - 1];
                }
                count++;
            }
            catch (IndexOutOfRangeException) {}
        }


        public void Remove(int index)
        {
            try
            {
                if (index < 0 || index >= capacity) throw new IndexOutOfRangeException();
                if (index > count - 1) return;

                T[] temp_array = new T[capacity];
                for (int i = count - 2; i >= 0; i--)
                {
                    if (i >= index) temp_array[i] = array[i + 1];
                    else temp_array[i] = array[i];
                }
                array = temp_array;
                count--;
                if (count < capacity / 2) { MakeArray(capacity / 2); }
            }
            catch (IndexOutOfRangeException) { }
        }
    }
}