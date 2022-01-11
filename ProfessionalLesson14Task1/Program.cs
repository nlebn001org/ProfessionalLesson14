using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProfessionalLesson14Task1
{
    internal class Program
    {
        static int x = 0;
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread ID {Thread.CurrentThread.ManagedThreadId} started");
            for (int i = 0; i < 3; i++)
                ItterateAsync().Wait();
            Console.WriteLine($"Main Thread ID {Thread.CurrentThread.ManagedThreadId} started");
        }


        static void Itterate()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}, Itteration - {++x}");
        }
        static async Task ItterateAsync()
        {
            await Task.Run(() => Itterate());
        }

    }
}
