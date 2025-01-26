using System.Diagnostics;

namespace Homework03
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var stopWatch = new Stopwatch();

            Console.WriteLine("Задание 1, чтение трех файлов параллельно и подсчет пробелов в них.");
            List<Task<int>> tasks = new List<Task<int>>();
            stopWatch.Start();
            tasks.Add(CalculateSpaces("../../../Files/version2.txt"));
            tasks.Add(CalculateSpaces("../../../Files/version3.txt"));
            tasks.Add(CalculateSpaces("../../../Files/version4.txt"));
            await Task.WhenAll(tasks);
            stopWatch.Stop();
            Console.WriteLine($"Время, потраченное на выполнение задачи 1: {stopWatch.Elapsed}.");

            Console.WriteLine("Задание 2, чтение всех файлов из указанной папки параллельно и подсчет пробелов в них.");
            stopWatch.Restart();
            await CalculateSpacesInDirectory("../../../Files");
            stopWatch.Stop();
            Console.WriteLine($"Время, потраченное на выполнение задачи 2: {stopWatch.Elapsed}.");
        }

        static async Task<int> CalculateSpaces(string FilePath)
        {
            FileInfo fileInfo = new FileInfo(FilePath);
            if (fileInfo.Exists)
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string text = await reader.ReadToEndAsync();
                    int result = text.Count(Char.IsWhiteSpace);
                    //await DoDelay();
                    Console.WriteLine($"В файле {FilePath} {result} пробелов.");
                    return result;
                }
            }
            else
            {
                Console.WriteLine($"Файл {FilePath} не найден в папке {fileInfo.DirectoryName}.");
                return 0;
            }
        }

        static async Task CalculateSpacesInDirectory(string Path)
        {
            if (Directory.Exists(Path))
            {
                string[] files = Directory.GetFiles(Path);
                List<Task<int>> tasks = new List<Task<int>>();
                foreach (string file in files)
                    tasks.Add(CalculateSpaces(file));
                await Task.WhenAll(tasks);
            }
        }

        // Можно использовать для имитации длительного чтения
        //static async Task LocalDelay()
        //{
        //    int timeOnOperationMs = new Random().Next(1000, 8000);
        //    await Task.Delay(TimeSpan.FromMilliseconds(timeOnOperationMs));
        //}
    }
}
