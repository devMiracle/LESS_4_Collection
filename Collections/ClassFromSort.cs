using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    
    //класс сортировки на положительное и четное введеному значению
    class SortInputNumber : IComparer<int>
    {
        private Predicate<int> predicate = (int x) =>
        {


            return false;
        };
        public int Compare(int x, int y)
        {
                if (x < y)
                    return -1;
                else if (x > y)
                    return 1;
                else
                    return 0;
        }
    }
    //класс сортировки на простое число
    class SortPrime : IComparer<int>
    {
        //предикат. проверка чистла на (простое)
        private Predicate<int> isPrimeNumber = (int x) => 
        {
            if (x < 0)
                throw new ArgumentException();
            for (int i = 2; i <= x / 2; i++)
            {
                if (x % i == 0)
                    return false;
            }
            return true;
        };
        //метод. позволяет проверить число предикатом
        public bool IsPrimeNumber(int x)
        {
            if (x < 0)
                throw new ArgumentException();
            return isPrimeNumber(x) ? true : false;
        }
        //метод для сравнения
        public int Compare(int x, int y)
        {
            if (x < 0 | y < 0)
                throw new ArgumentException();


            if (isPrimeNumber(x) & !isPrimeNumber(y))
                return 1;
            else if (!isPrimeNumber(x) & isPrimeNumber(y))
                return -1;
            //else if (isPrimeNumber(x) & isPrimeNumber(y))
            //    return 0;
            //else if (!isPrimeNumber(x) & !isPrimeNumber(y))
            //    return 0;
            return 0;
        }
    }
}
