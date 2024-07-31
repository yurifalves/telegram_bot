using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        await Demo();
        Console.ReadLine();
    }

    public static async Task Demo()
    {
        var watch = new Stopwatch();
        watch.Start();


        // Aguarde todas as tarefas concluírem
        await StartSchoolAssembly();
        await TeachClass12();
        await TeachClass11();

        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }

    public static async Task StartSchoolAssembly()
    {
        await Task.Run(() =>
        {
          Func<int, int, int> add = (a, b) => a + b;
            Task.Delay(8000).Wait(); // Task.Delay é preferível a Thread.Sleep
            Console.WriteLine("School Started");
        });
    }

    public static async Task TeachClass12()
    {
        await Task.Run(() =>
        {
            Task.Delay(3000).Wait(); // Task.Delay é preferível a Thread.Sleep
            Console.WriteLine("Taught class 12");
        });
    }

    public static async Task TeachClass11()
    {
        await Task.Run(() =>
        {
            Task.Delay(2000).Wait(); // Task.Delay é preferível a Thread.Sleep
            Console.WriteLine("Taught class 11");
        });
    }
}
