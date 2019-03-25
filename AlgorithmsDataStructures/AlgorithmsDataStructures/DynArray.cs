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
                
                array = new T[capacity];
                
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
            catch (ArgumentOutOfRangeException) { }
            return default(T);
        }


        public void Append(T itm)
        {
            if (count == array.Length) MakeArray(array.Length * 2);
            array[count] = itm;
            count++;
        }

        // Сложность схожая с методом Remove() за исключением дополнительного вызова метода Copy() в методе Remove()
        public void Insert(T itm, int index)
        {
            T[] temp_array = new T[array.Length];
            array.CopyTo(temp_array, 0);
            try
            {
                if (index < 0 || index >= capacity) throw new ArgumentOutOfRangeException();
                if (count == array.Length) MakeArray(array.Length * 2);
                Array.Copy(temp_array, index, array, index+1, count-index);
                array[index] = itm;
                count++;
            }
            catch (ArgumentOutOfRangeException)
            {
                array = temp_array;
                capacity = temp_array.Length;
            }
        }

        // Сложность схожая с методом Insert() за исключением дополнительной операции с копированием значений до указанного элемента,
        // затем чтобы все остальные элементы после указанного сместить в его сторону.
        // Дополнительно проводится проверка на минимальный размер буфера 
        public void Remove(int index)
        {
            T[] temp_array = new T[array.Length];
            array.CopyTo(temp_array, 0);
            array = new T[capacity];
            try
            {
                if (index < 0 || index >= capacity) throw new ArgumentOutOfRangeException();
                Array.Copy(temp_array, 0, array, 0, index);
                Array.Copy(temp_array, index + 1, array, index, count - index - 1);
                count--;
                if (count < capacity / 2) { MakeArray(capacity / 2); }
            }
            catch (ArgumentOutOfRangeException)
            {
                array = temp_array;
                capacity = temp_array.Length;
            }
        }
    }
}