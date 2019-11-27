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
}
