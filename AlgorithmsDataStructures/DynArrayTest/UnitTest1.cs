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
        public void AppendOverLoadTest()
        {
            DynArray<int> dya = new DynArray<int>();
            //Создание 17-и элементов.
            for (int i = 1; i < 18; i++)
            {
                dya.Append(i);
            }
            //Проверка значения 0-го элемента
            Assert.AreEqual(1, dya.GetItem(0));
            //Проверка значения 11-го элемента
            Assert.AreEqual(12, dya.GetItem(11));
            //Проверка значения 16-го элемента
            Assert.AreEqual(17, dya.GetItem(16));
        }

        [TestMethod]
        public void InsertTest_1()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 1; i < 9; i++)
            {
                dya.Append(i);
            }

            Assert.AreEqual(1, dya.GetItem(0));
            dya.Insert(100, 0);
            Assert.AreEqual(100, dya.GetItem(0));
            Assert.AreEqual(1, dya.GetItem(1));
            Assert.AreEqual(9, dya.count);
        }

        [TestMethod]
        public void InsertTest_2()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 1; i < 9; i++)
            {
                dya.Append(i);
            }

            dya.Insert(100, 7);
            Assert.AreEqual(100, dya.GetItem(7));
            Assert.AreEqual(8, dya.GetItem(8));
            Assert.AreEqual(9, dya.count);
        }

        [TestMethod]
        public void InsertOverLoadTest()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 1; i < 17; i++)
            {
                dya.Append(i);
            }

            Assert.AreEqual(16, dya.GetItem(15));
            Assert.AreEqual(0, dya.GetItem(16));
            dya.Insert(100, 15);
            Assert.AreEqual(100, dya.GetItem(15));

            Assert.AreEqual(16, dya.GetItem(16));
        }

        [TestMethod]
        public void InsertOverLoadTest_2()
        {
            //Создание массива и назначение массиву 16 элементов
            //
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 17; i++)
            {
                dya.Append(i);
            }

            //Проверка значения 16-го элемента
            Assert.AreEqual(15, dya.GetItem(15));
            //Вставка 17-го элемента в массив и увеличение ёмкости массива
            dya.Insert(100, 16);
            //Проверка значения 17-го элемента
            Assert.AreEqual(100, dya.GetItem(16));
        }

        [TestMethod]
        public void RemoveTest()
        {
            //Создание массива и назначение массиву 16 элементов
            //
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 4; i++)
            {
                dya.Append(i);
            }
            //Проверка длины рабочего массива
            Assert.AreEqual(4, dya.count);
            //Удаление 2-го элемента массива
            dya.Remove(1);
            //Проверка длины рабочего массива
            Assert.AreEqual(3, dya.count);
            //Проверка значения 2-го элемента
            Assert.AreEqual(2, dya.GetItem(1));
        }

        [TestMethod]
        public void RemoveDecreaseTest_1()
        {
            //Создание массива и назначение массиву 16 элементов
            //
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 33; i++)
            {
                dya.Append(i);
            }
            //Удаление 2-го элемента массива
            dya.Remove(1);
            //Проверка значения второго элемента
            Assert.AreEqual(2, dya.GetItem(1));
        }
    }
}