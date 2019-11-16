using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    //класс сортировки чисел с отверствиями
    class SortByZeroInNumber
    {
        //TODO: допилить
    }

    //класс сортировки на положительное и четное введеному значению
    class SortInputNumber : IComparer<int>
    {
        public static int? NumberInput { get; set; } = null;
        //предикат для проверки на положительное и кратное числу, введенное пользователем
        private readonly Predicate<int> predicate = (int x) =>
        {
            if (!(NumberInput is null))
                return x > 0 & x % NumberInput == 0 ? true : false;
            else
                throw new ArgumentException();
        };
        //метод. позволяет проверить число предикатом
        public bool Foo(int x)
        {
            if (x < 0)
                throw new ArgumentException();
            return predicate(x) ? true : false;
        }
        //метод для сравнения
        public int Compare(int x, int y)
        {
            if (x < 0 | y < 0)
                throw new ArgumentException();
            if (predicate(x) & !predicate(y))
                return 1;
            else if (!predicate(x) & predicate(y))
                return -1;
            return 0;
        }
    }
    //класс сортировки на простое число
    class SortPrime : IComparer<int>
    {
        //предикат. проверка чистла на (простое)
        private readonly Predicate<int> isPrimeNumber = (int x) => 
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
        public bool Foo(int x)
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
