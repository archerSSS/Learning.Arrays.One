using System;
using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynArrayTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AppendTest()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 12; i++)
            {
                dya.Append(i);
            }
            Assert.AreEqual(0, dya.GetItem(0));
            Assert.AreEqual(11, dya.GetItem(11));
            Assert.AreEqual(12, dya.count);
        }

        [TestMethod]
        public void InsertTest()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 12; i++)
            {
                dya.Append(i);
            }

            //Проверка значений элементов(5-го и 6-го) до вставки нового
            //
            Assert.AreEqual(5, dya.GetItem(5));
            Assert.AreEqual(6, dya.GetItem(6));

            //Проверка значения 11-го элемента(последнего добавленного) до вставки нового
            Assert.AreEqual(11, dya.GetItem(11));

            //Проверка значения 12-го элемента(после последнего добавленного)  до вставки нового
            Assert.AreEqual(0, dya.GetItem(12));

            //Проверка на количество элементов до вставки
            Assert.AreEqual(12, dya.count);

            //Проверка размера буфера до вставки
            //
            Assert.AreEqual(16, dya.capacity);
            Assert.AreEqual(16, dya.array.Length);

            //Вставка нового элемента на место 5-го элемента
            dya.Insert(300, 5);

            //Проверка значений элементов(5-го и 6-го) после вставки нового
            //
            Assert.AreEqual(300, dya.GetItem(5));
            Assert.AreEqual(5, dya.GetItem(6));

            //Проверка значений 11-го и 12-го элементов после вставки нового
            //
            Assert.AreEqual(10, dya.GetItem(11));
            Assert.AreEqual(11, dya.GetItem(12));

            //Проверка на количество элементов после вставки
            Assert.AreEqual(13, dya.count);

            //Проверка размера буфера после вставки
            //
            Assert.AreEqual(16, dya.capacity);
            Assert.AreEqual(16, dya.array.Length);
        }

        [TestMethod]
        public void InsertOverLoadTest()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 16; i++)
            {
                dya.Append(i);
            }

            //Проверка значений элементов(5-го и 6-го) до вставки нового
            //
            Assert.AreEqual(5, dya.GetItem(5));
            Assert.AreEqual(6, dya.GetItem(6));

            //Проверка значения 15-го элемента(последнего добавленного) до вставки нового
            Assert.AreEqual(15, dya.GetItem(15));

            //Проверка значения 16-го элемента(после последнего добавленного) до вставки нового
            Assert.AreEqual(0, dya.GetItem(16));

            //Проверка на количество элементов до вставки
            Assert.AreEqual(16, dya.count);

            //Проверка размера буфера до вставки
            //
            Assert.AreEqual(16, dya.capacity);
            Assert.AreEqual(16, dya.array.Length);

            //Вставка нового элемента на место 5-го элемента
            dya.Insert(300, 5);

            //Проверка значений элементов(5-го и 6-го) после вставки нового
            //
            Assert.AreEqual(300, dya.GetItem(5));
            Assert.AreEqual(5, dya.GetItem(6));

            //Проверка значений 11-го и 12-го элементов после вставки нового
            //
            Assert.AreEqual(10, dya.GetItem(11));
            Assert.AreEqual(11, dya.GetItem(12));

            //Проверка на количество элементов после вставки
            Assert.AreEqual(17, dya.count);

            //Проверка размера буфера после вставки
            //
            Assert.AreEqual(32, dya.capacity);
            Assert.AreEqual(32, dya.array.Length);
        }

        [TestMethod]
        public void InsertWrongIndexTest()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 16; i++)
            {
                dya.Append(i);
            }
            dya.Insert(100, 17);

            //Проверка на отсутствие изменений
            Assert.AreEqual(0, dya.GetItem(17));

            //Проверка размера буфера после попытки вставки
            //
            Assert.AreEqual(16, dya.array.Length);
            Assert.AreEqual(16, dya.capacity);
        }

        [TestMethod]
        public void RemoveTest()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 16; i++)
            {
                dya.Append(i);
            }
            dya.Remove(0);

            //Проверка на смещение элементов
            for (int i = 0; i < dya.count; i++)
            {
                Assert.AreEqual(i+1, dya.GetItem(i));
            }

            //Проверка на отсутствие элемента в конце после смещения
            Assert.AreEqual(0, dya.GetItem(15));

            //Проверка размера буфера после удаления
            //
            Assert.AreEqual(16, dya.array.Length);
            Assert.AreEqual(16, dya.capacity);

            //Проверка длины массива
            Assert.AreEqual(15, dya.count);
        }

        [TestMethod]
        public void RemoveRangeDecreaseTest()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 33; i++)
            {
                dya.Append(i);
            }
            dya.Remove(5);

            //Проверка на отсутствие изменения размера буфера после удаления одного элемента
            //
            Assert.AreEqual(64, dya.capacity);
            Assert.AreEqual(64, dya.array.Length);

            dya.Remove(5);

            //Проверка размера буфера после удаления одного элемента
            //
            Assert.AreEqual(32, dya.capacity);
            Assert.AreEqual(32, dya.array.Length);

            //Проверка длины массива
            Assert.AreEqual(31, dya.count);
        }

        [TestMethod]
        public void RemoveWrongIndexTest()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 16; i++)
            {
                dya.Append(i);
            }
            
            dya.Remove(17);

            //Проверка на отсутствие изменений
            //
            for (int i = 0; i < dya.capacity; i++)
            {
                Assert.AreEqual(i, dya.GetItem(i));
            }
        }
    }
}