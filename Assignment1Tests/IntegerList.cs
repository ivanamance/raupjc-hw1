using System;
using System.Collections;
using System.Linq;
using Assignment1Tests;

namespace Assignment1Tests
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        public IntegerList()
        {
            _internalStorage = new int[4];

        }

        public IntegerList(int initalSize)
        {
            _internalStorage = new int[initalSize];

        }

        private int _count;

        public int Count => _count;


        public void Add(int item)
        {
            if (_count == _internalStorage.Length)
            {
                Array.Resize(ref _internalStorage, 2 * _internalStorage.Length);
            }
            _internalStorage[_count] = item;
            _count++;

        }

        public bool Remove(int item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_internalStorage[i] == item)
                {

                    return (RemoveAt(i));
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= _count)
            {
                throw new IndexOutOfRangeException();

            }
            for (int i = index; i < _count; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _count--;
            return true;
        }

        public int GetElement(int index)
        {
            if (index >= _count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _internalStorage[index];
            }
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_internalStorage[i] == item) return i;
            }
            return -1;
        }

        

        public void Clear()
        {
            while (_count != 0)
            {
                RemoveAt(_count-1);
            }
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_internalStorage[i] == item) return true;
            }
            return false;
        }


        public static void ListExample(IIntegerList listOfIntegers)
        {
            listOfIntegers.Add(1); // [1]
            listOfIntegers.Add(2); // [1 ,2]
            listOfIntegers.Add(3); // [1 ,2 ,3]
            listOfIntegers.Add(4); // [1 ,2 ,3 ,4]
            listOfIntegers.Add(5); // [1 ,2 ,3 ,4 ,5]
            listOfIntegers.RemoveAt(0); // [2 ,3 ,4 ,5]
            listOfIntegers.Remove(5); // [2 ,3 ,4]
            Console.WriteLine(listOfIntegers.Count ); // 3
            Console.WriteLine(listOfIntegers.Remove (100)); // false
            Console.WriteLine(listOfIntegers.RemoveAt (5)); // false
            listOfIntegers.Clear(); // []
            Console.WriteLine(listOfIntegers.Count ); // 0
        }

        public static void Main(string[] args)
        {
            
        }
    }
}
