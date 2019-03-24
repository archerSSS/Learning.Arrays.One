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

                //Создание *нового временного массива с новой длинной
                T[] temp_array = new T[capacity];
                //Копирование *элементов старого массива в новый
                Array.Copy(array, 0, temp_array, 0, count);

                //Назначение *нового размера старому массиву.
                array = new T[capacity];

                //Копирование *элементов временного массива старому
                Array.Copy(temp_array, 0, array, 0, count);
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
            if (count == array.Length) MakeArray(array.Length * 2);
            array[count] = itm;
            count++;
        }


        public void Insert(T itm, int index)
        {
            T[] temp_array = new T[array.Length];
            array.CopyTo(temp_array, 0);

            try
            {
                if (count == array.Length) MakeArray(array.Length * 2);
                for (int i = count + 1; i > index; i--)
                {
                    array[i] = array[i - 1];
                }
                array[index] = itm;
                count++;
            }
            catch (IndexOutOfRangeException) { array = temp_array; }
        }


        public void Remove(int index)
        {
            try
            {
                Array.Copy(array, index + 1, array, index, count - index - 1);
            }
            catch (IndexOutOfRangeException) { }
            count--;
            if (count < capacity / 1.5) { MakeArray((int)(capacity / 1.5)); }
        }
    }
}