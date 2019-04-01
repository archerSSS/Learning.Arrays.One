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
            
            Assert.AreEqual(16, dya.count);
            Assert.AreEqual(16, dya.capacity);
            
            dya.Insert(300, 5);
            
            Assert.AreEqual(300, dya.GetItem(5));
            Assert.AreEqual(5, dya.GetItem(6));
            
            Assert.AreEqual(17, dya.count);
            Assert.AreEqual(32, dya.capacity);
        }


        //Добавляет 16 элементов и вставляет один на место 16-го и увеличивает размер буфера
        //
        [TestMethod]
        public void InsertOverLoadTest_2()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 16; i++) { dya.Insert(i, i); }

            Assert.AreEqual(15, dya.GetItem(15));
            Assert.AreEqual(16, dya.count);

            dya.Insert(100, 15);

            Assert.AreEqual(32, dya.capacity);
            Assert.AreEqual(32, dya.array.Length);

            Assert.AreEqual(14, dya.GetItem(14));
            Assert.AreEqual(100, dya.GetItem(15));
            Assert.AreEqual(15, dya.GetItem(16));
        }


        //Добавляет 16 элементов и проводится попытка вставить один за пределами буфера
        [TestMethod]
        public void InsertOverLoadTest_3()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 16; i++) { dya.Insert(i, i); }

            Assert.AreEqual(15, dya.GetItem(15));
            Assert.AreEqual(16, dya.count);

            dya.Insert(100, 16);

            Assert.AreEqual(32, dya.capacity);

            Assert.AreEqual(14, dya.GetItem(14));
            Assert.AreEqual(100, dya.GetItem(16));
            Assert.AreEqual(15, dya.GetItem(15));
        }


        [TestMethod]
        public void InsertWrongIndexTest_1()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 16; i++)
            {
                dya.Append(i);
            }
            dya.Insert(100, 17);
            
            Assert.AreEqual(0, dya.GetItem(17));

            Assert.AreEqual(16, dya.capacity);
            Assert.AreEqual(16, dya.count);
        }


        [TestMethod]
        public void InsertWrongIndexTest_2()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 16; i++)
            {
                dya.Append(i);
            }

            dya.Insert(100, -1);
            
            Assert.AreEqual(0, dya.GetItem(-1));
            
            Assert.AreEqual(16, dya.capacity);
            Assert.AreEqual(16, dya.count);
        }


        [TestMethod]
        public void InsertWrongIndexTest_3()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 8; i++)
            {
                dya.Append(i);
            }
            dya.Insert(100, 16);
            
            Assert.AreEqual(0, dya.GetItem(16));
            
            Assert.AreEqual(16, dya.capacity);
            Assert.AreEqual(8, dya.count);
        }


        [TestMethod]
        public void InsertWrongIndexTest_4()
        {
            DynArray<int> dya = new DynArray<int>();
            
            dya.Insert(100, 16);

            Assert.AreEqual(0, dya.GetItem(16));

            Assert.AreEqual(16, dya.capacity);
            Assert.AreEqual(0, dya.count);
        }


        [TestMethod]
        public void InsertWrongIndexTest_5()
        {
            DynArray<Obj> dya = new DynArray<Obj>();
            for (int i = 0; i < 15; i++)
            {
                dya.Append(new Obj(i));
            }
            Obj o1 = dya.GetItem(14);
            Obj o2 = dya.GetItem(13);

            dya.Insert(new Obj(16), 16);

            Assert.AreEqual(null, dya.GetItem(16));
            Assert.AreEqual(o1, dya.GetItem(14));

            Assert.AreEqual(16, dya.capacity);
            Assert.AreEqual(15, dya.count);
        }


        [TestMethod]
        public void RemoveTest_1()
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
        public void RemoveTest_2()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 17; i++)
            {
                dya.Append(i);
            }

            for (int i = 0; i < 17; i++)
            {
                Assert.AreEqual(i, dya.GetItem(0));
                dya.Remove(0);
            }

            Assert.AreEqual(16, dya.capacity);
            Assert.AreEqual(0, dya.count);
        }


        [TestMethod]
        public void RemoveTest_3()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 1; i < 4; i++)
            {
                dya.Append(i);
            }

            dya.Remove(1);
            Assert.AreEqual(1, dya.GetItem(0));
            Assert.AreEqual(3, dya.GetItem(1));
            Assert.AreEqual(0, dya.GetItem(2));
            dya.Remove(1);
            Assert.AreEqual(1, dya.GetItem(0));
            Assert.AreEqual(0, dya.GetItem(1));
            dya.Remove(0);
            Assert.AreEqual(0, dya.GetItem(0));
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

        //Попытка удаления элемента за пределами границ массива
        [TestMethod]
        public void RemoveWrongIndexTest_1()
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


        [TestMethod]
        public void RemoveWrongIndexTest_2()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 2; i++)
            {
                dya.Append(i);
            }

            dya.Remove(5);

            Assert.AreEqual(2, dya.count);
            Assert.AreEqual(0, dya.GetItem(0));
            Assert.AreEqual(1, dya.GetItem(1));
            Assert.AreEqual(0, dya.GetItem(2));
        }


        [TestMethod]
        public void RemoveWrongIndexTest_3()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 2; i++)
            {
                dya.Append(i);
            }

            dya.Remove(-1);

            Assert.AreEqual(2, dya.count);
            Assert.AreEqual(0, dya.GetItem(0));
            Assert.AreEqual(1, dya.GetItem(1));
            Assert.AreEqual(0, dya.GetItem(-1));
        }


        [TestMethod]
        public void MyRemoveTest()
        {
            DynArray<int> dya = new DynArray<int>();
            for (int i = 0; i < 10; i++)
            {
                dya.Append(i);
            }

            dya.Remove(0);
            dya.Remove(100);
            dya.Remove(14);
            dya.Remove(1);
        }
    }
}