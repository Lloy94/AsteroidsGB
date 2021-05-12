using System;

namespace MyDelegate
{
    delegate T MyDelegegate<T>(T obj1, T obj2);

    class DelegateSum
    {
        public static int SumInt(int a, int b)
        {
            return a + b;
        }

        public static string SumStr(string s1, string s2)
        {
            return s1 + " " + s2;
        }

        public static char SumCh(char a, char b)
        {
            return (char)(a + b);
        }
    }

    class Program
    {
        static void Main()
        {
            MyDelegegate<int> del1 = DelegateSum.SumInt;
            Console.WriteLine("6 + 7 = " + del1(6, 7));

            MyDelegegate<string> del2 = DelegateSum.SumStr;
            Console.WriteLine("\"Отличная\" + \"погода\" = " + del2("Отличная", "погода"));

            MyDelegegate<char> del3 = DelegateSum.SumCh;
            Console.WriteLine("'a' + 'c' = " + del3('a', 'c'));

            Console.ReadLine();
        }
    }
}