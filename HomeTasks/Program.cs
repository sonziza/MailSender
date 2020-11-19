using System;
using System.Threading;
using System.Threading.Tasks;

namespace HomeTasks
{
    class Program
    {
        static void Main(string[] args)
        //{
        //    Parallel.For(1, 10, Factorial);

        //    Console.ReadLine();
        //}

        //static void Factorial(int x)
        //{
        //    int result = 1;

        //    for (int i = 1; i <= x; i++)
        //    {
        //        result *= i;
        //    }
        //    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        //    Thread.Sleep(3000);
        //    Console.WriteLine($"Факториал числа {x} равен {result}");
        //}

        {
            int n = 10;
            int[,] A = new int[n, n];
            int[,] B = new int[n, n];
            int[,] C = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = rnd.Next(0, 5);
                    B[i, j] = rnd.Next(0, 5);
                }
            }


            Console.WriteLine(">>>Начало вычислений");

            C = ArrMul(A, B, n);

            Console.WriteLine(">>>Конец вычислений");
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        Console.Write(C[i, j] + "\t");
            //    }
            //    Console.WriteLine();
            //}
            //Parallel.For(0, 100, s => )
            Console.WriteLine(">>>Главный поток - конец");
            Console.ReadLine();
        }

        static int[,] ArrMul(int[,] arrayA, int[,] arrayB, int n)
        {
            int[,] arrRes = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                //for (int j = 0; j < n; j++)
                Parallel.For(0, n, j =>
            {
                for (int k = 0; k < n; k++)
                {
                    arrRes[i, j] += arrayA[i, k] * arrayB[k, j];
                        //Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                        Thread.Sleep(1);
                        //Console.WriteLine($"Задача {Task.CurrentId} выполнена");

                        //for (int k = 0; k < n; k++)
                        //{
                        //    arrRes[i, j] += arrayA[i, k] * arrayB[k, j];
                        //};
                    }
            });
                Console.Write("*");
            }
            Console.WriteLine();
            return arrRes;
        }

        
    }
}
