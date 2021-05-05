using System;

namespace Workers
{
    class Program
    {
        private static Random random = new Random();

        static Worker GenerateWorker()
        {
            var names = new[] { "Анатолий", "Глеб", "Клим", "Мартин", "Лазарь", "Владлен", "Клим", "Панкратий", "Рубен", "Герман" };
            var surnames = new[] { "Григорьев", "Фокин", "Шестаков", "Хохлов", "Шубин", "Бирюков", "Копылов", "Горбунов", "Лыткин", "Соколов" };

            var typeIndex = random.Next(0, 2);
            var salary = random.Next(200, 501);
            var salaryIndex = random.Next(100, 160);
            var age = random.Next(18, 45);
            switch (typeIndex)
            {
                case 0:
                    return new FreelanceWorker(names[random.Next(0, 10)], surnames[random.Next(0, 10)],age, salary);
                case 1:
                    return new FixedWorker(names[random.Next(0, 10)], surnames[random.Next(0, 10)],age, salary * salaryIndex);
            }
            return null;
        }


        private static void Main(string[] args)
        {
            Worker [] workers = new Worker [10];
            for (int i = 0; i < workers.Length; i++)
                workers[i] = GenerateWorker();

            foreach (var employee in workers)
                Console.WriteLine(employee);

            Console.WriteLine();
            Array.Sort(workers, new SalaryComparer());

            Console.WriteLine("\n*** Отсортированный массив сотрудников ***\n");
            foreach (var employee in workers)
                Console.WriteLine(employee);

            Console.ReadKey();
        }
    }
}
