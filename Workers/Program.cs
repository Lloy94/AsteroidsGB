using System;

namespace Workers
{
    class Program
    {
        private static void Main(string[] args)
        {
            var workers = new Worker[]
            {
                new FixedWorker("Тимофеев","Илья", 26),
                new HourWorker("Демидова","Мария", 33),
                new HourWorker("Белякова","Светлана", 31),
                new FixedWorker("Ржевский","Иван", 18),
                new HourWorker("Бледный","Андрей", 18)
            };

            Array.Sort(workers);

            foreach(Worker worker in workers)
                Console.WriteLine($"{worker.SecondName} {worker.Name} - {worker.Age}");

            Console.ReadKey();
        }
    }
}
