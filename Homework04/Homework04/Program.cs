using System;
using System.Diagnostics;
using Microsoft.Win32.SafeHandles;

namespace Homework04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randSeed = new Random();
            int[] sizes = { 100_000, 1_000_000, 10_000_000 };
            const string rowDelimeter = "├─────────────────┼───────────┼──────────────┤";
            const string rowData = "│ {0, -15} │ {1, 9} │ {2, 12} │";

            foreach (int size in sizes)
            {
                Console.WriteLine($"Обработка {size} элементов");
                Console.WriteLine($"┌─────────────────┬───────────┬──────────────┐");
                Console.WriteLine(rowData, "Тип", "Время, мс", "Сумма");
                Console.WriteLine(rowDelimeter);

                var data = Enumerable.Repeat(0, size).Select(i => randSeed.Next(255)).ToArray();
                var stopWatch = Stopwatch.StartNew();
                long sumResult = RegularSum(data);
                stopWatch.Stop();
                
                Console.WriteLine(rowData, "Последовательно", stopWatch.ElapsedMilliseconds, sumResult);
                Console.WriteLine(rowDelimeter);

                stopWatch.Restart();
                sumResult = ParallelSum(data);
                stopWatch.Stop();

                Console.WriteLine(rowData, "Параллельно", stopWatch.ElapsedMilliseconds, sumResult);
                Console.WriteLine(rowDelimeter);

                stopWatch.Restart();
                sumResult = PLINQSum(data);
                stopWatch.Stop();
                Console.WriteLine(rowData, "PLINQ", stopWatch.ElapsedMilliseconds, sumResult);
                Console.WriteLine($"└─────────────────┴───────────┴──────────────┘");
                Console.WriteLine();
            }
        }

        static long RegularSum(int[] data)
        {
            return data.Sum(i => (long)i);
        }

        static long ParallelSum(int[] data)
        {
            long total = 0;
            int threadsCount = 4;
            var partSize = data.Length / threadsCount;
            List<Thread> threadsList = new List<Thread>();
            for (int i = 0; i < threadsCount; i++)
            {
                var localIndex = i;
                Thread thread = new Thread(() =>
                    {
                        long localTotal = 0;
                        for (int j = localIndex * partSize; j < (localIndex + 1) * partSize; j++)
                            localTotal += data[j];
                        Interlocked.Add(ref total, localTotal);
                    });
                thread.IsBackground = true;
                threadsList.Add(thread);
                thread.Start();
            }

            foreach (var thread in threadsList)
            {
                thread.Join();
            }

            return total;
        }
        
        static long PLINQSum(int[] data)
        {
            return data.AsParallel().Sum(i => (long)i);
        }
    }
}
