using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        public static void Task2()
        {
            Random random = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                list.Add(random.Next(0, 10)); // Заполним коллекцию случайными числами
            }

            // Создадим вспомогательный словарь (ключ - элемент коллекции, значение - кол-во повторений)
            Dictionary<int, int> statistic = new Dictionary<int, int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (statistic.ContainsKey(list[i]))
                    statistic[list[i]]++;
                else
                    statistic.Add(list[i], 1);
            }

            // Выводим результат подсчета (2.a)
            foreach (var pair in statistic)
                Console.WriteLine($"{pair.Key} -> {pair.Value}");

            Console.WriteLine();

            ArrayList list02 = new ArrayList();

            // Заполним коллекцию случайными ОБЪЕКТАМИ
            for (int i = 0; i < 15; i++)
            {
                // Получим индекс случайного элемента
                switch (random.Next(0, 5))
                {
                    case 0:
                        list02.Add(false);
                        break;
                    case 1:
                        list02.Add("Hello");
                        break;
                    case 2:
                        list02.Add(13);
                        break;
                    case 3:
                        list02.Add(new object());
                        break;
                    case 4:
                        list02.Add(true);
                        break;
                }
            }

            // Создадим вспомогательный словарь (ключ - элемент коллекции, значение - кол-во повторений)
            Dictionary<object, int> statistic02 = new Dictionary<object, int>();
            for (int i = 0; i < list02.Count; i++)
            {
                if (statistic02.ContainsKey(list02[i]))
                    statistic02[list02[i]]++;
                else
                    statistic02.Add(list02[i], 1);
            }

            // Выводим результат подсчета (2.б)
            foreach (var pair in statistic02)
                Console.WriteLine($"{pair.Key} -> {pair.Value}");

            Console.WriteLine();

            // Посчитаем статистику вхождения и вывоз результата испльзуя Linq (2.в):
            foreach (var value in list.Distinct())
                Console.WriteLine($"{value} -> {list.Where(x => x == value).Count()}");
        }
        static void Main(string[] args)
        {
            Task2();
            Console.WriteLine();
            Dictionary<string, int> dict = new Dictionary<string, int>()
                  {
                    {"four",4 },
                    {"two",2 },
                    { "one",1 },
                    {"three",3 },
                  };
            var d = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
    }
}
