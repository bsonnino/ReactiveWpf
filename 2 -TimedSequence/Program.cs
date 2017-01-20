using System;
using System.Reactive.Linq;

namespace _2__TimedSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = Observable.Timer(TimeSpan.FromSeconds(2),TimeSpan.FromSeconds(1))
                .Select((t,i) => new
                {
                    Date = DateTime.Now,
                    Item = i
                });
            using (source.Subscribe(
                x => Console.WriteLine($"OnNext: {x.Date} - {x.Item}"),
                ex => Console.WriteLine($"OnError: {ex.Message}"),
                () => Console.WriteLine("OnCompleted"))) 
            {
                Console.WriteLine("Press ENTER to unsubscribe...");
                Console.ReadLine();
            }
        }
    }
}
