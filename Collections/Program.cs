using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


///1.Создать экземпляр класс упорядоченный список или любой другой контейнер с числовым типом.
///Заполнить список случайными значениями, в диапазоне, указанном пользователем.
///1.Описать функцию предикат, которая проверяет, является ли передаваемое число простым.
///2.Описать функцию предикат, определяющую является ли передаваемое число положительным и кратным значению, передаваемому вторым аргументом.
//3.Описать функцию, которая будет считать сумму цифр, которые содержат отверстие->(0698). Описать для поиска соответствующий
///4.Отсортировать список.используя описанные предикаты.

//2. К заданию про фигуры добавить возможность сортировки коллекции по площади фигуры.



//2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199

namespace Collections
{
    class Program
    {
        public static string NameRandomizer(List<string> names)
        {
            Random random = new Random();
            return names[random.Next(names.Count)];
        }
    
        static void Main(string[] args)
        {
            Console.SetWindowSize(60, 60);
            //это не по заданию
            //Console.SetBufferSize(30, 60);
            //Console.CursorVisible = false;
            ////создаём контейнер для хранения нашего класса Student
            //List<Student> students = new List<Student>();
            ////создаем лист имен для передачи в метод NameRandomizer
            //List<string> names = new List<string> { "Liza", "Aleksandr", "Aleksey", "Maksim", "Nika", "Ivan", "Lika", "Lola" };
            //Random random = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    students.Add((new Student(NameRandomizer(names), random.Next(18, 31))));
            //    Thread.Sleep(111);
            //}
            //foreach (var item in students)
            //{
            //    Console.WriteLine($"Name: {item.Name}, Age: {item.Age}");
            //}
            //Console.ReadKey(true);


            //а теперь к заданию.
            List<int> numbers = new List<int>();
            Random random0 = new Random();

            //спрашиваем у пользователя
            Console.WriteLine("Укажите диапазон значений: ");
            int firstInput, secondInput;
            bool isNumber = false;
            do
            {
                isNumber = Int32.TryParse(Console.ReadLine(), out firstInput);
            } while (!isNumber);
            do
            {
                isNumber = Int32.TryParse(Console.ReadLine(), out secondInput);
            } while (!isNumber);
            Console.WriteLine("Done!");
            if (firstInput > secondInput)
            {
                int temp = firstInput;
                firstInput = secondInput;
                secondInput = temp;
            }

            //заполняем лист
            for (int i = 0; i < 30; i++)
                numbers.Add(random0.Next(firstInput, secondInput + 1));

            #region FirstSort
            //создаем объект для сортировки
            SortPrime sortPrime = new SortPrime();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("First Sort");
            Console.ResetColor();
            //выводим в консоль список (до сортировки)
            Console.WriteLine("\nbefore sort");
            foreach (var item in numbers)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (sortPrime.Foo(item))
                    Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(item);
            }
            Console.ResetColor();

            //сортируем
            numbers.Sort(sortPrime);

            //выводим в консоль список (после сортировки)
            Console.WriteLine("\nAfter sort");
            foreach (var item in numbers)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (sortPrime.Foo(item))
                    Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(item);
            }
            Console.ResetColor();
            #endregion
            Console.WriteLine();
            #region SecondRegion
            //создаем объект для сортировки
            SortInputNumber sortInputNumber = new SortInputNumber();
            int inputNumber, multipleNumber;
            Console.WriteLine("Введите число: ");
            do
            {
                isNumber = Int32.TryParse(Console.ReadLine(), out inputNumber);
            } while (!isNumber);
            Console.WriteLine("Введите кратность этому числу: ");
            do
            {
                isNumber = Int32.TryParse(Console.ReadLine(), out multipleNumber);
            } while (!isNumber);
            SortInputNumber.NumberInput = multipleNumber;

            if (sortInputNumber.Foo(inputNumber))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Является! Положительным и кратным числу: {multipleNumber}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не является :(");
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nА также List кратный: {multipleNumber}");
            Console.ResetColor();
            //выводим в консоль список (до сортировки)
            Console.WriteLine("\nbefore sort");
            foreach (var item in numbers)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (sortInputNumber.Foo(item))
                    Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(item);
            }
            Console.ResetColor();

            //сортируем
            numbers.Sort(sortInputNumber);

            //выводим в консоль список (после сортировки)
            Console.WriteLine("\nAfter sort");
            foreach (var item in numbers)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (sortInputNumber.Foo(item))
                    Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(item);
            }
            Console.ResetColor();
            #endregion








            Console.ReadKey(true);
        }


    }
}
