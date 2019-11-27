using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections 
{
    //класс сортировки чисел с отверствиями сумма => (0698) 
    class SortByZeroInNumber : IComparer<int>
    {
        private readonly Predicate<int> predicate = (int x) =>
        {
            char[] number = x.ToString().ToCharArray();
            for (int i = 0; i < number.Length; i++)
                if (number[i] == '0' || number[i] == '6' || number[i] == '9' || number[i] == '8')
                    return true;
            return false;
        };
        //метод. позволяет проверить число предикатом
        public bool Foo(int x)
        {
            if (x < 0)
                throw new ArgumentException();
            return predicate(x) ? true : false;
        }
        //подсчитывает сумму цифр в числе с отверстием (0698)
        public int Sum(int number)
        {
            if (predicate(number))
            {
                char[] numTmp = number.ToString().ToCharArray();
                int sum = 0;
                for (int i = 0; i < numTmp.Length; i++)
                    sum += int.Parse(numTmp[i].ToString());
                return sum;
            }
            return 0;
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
