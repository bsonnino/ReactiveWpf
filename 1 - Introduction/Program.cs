using System;
using System.Reactive;
using System.Reactive.Linq;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            IObservable<int> source = Observable.Range(1, 10)
                .Where(x => x % 2 == 0)
                .Select(x => x * x);
            IObserver<int> obsvr = Observer.Create<int>(
                x => Console.WriteLine("OnNext: {0}", x),
                ex => Console.WriteLine("OnError: {0}", ex.Message),
                () => Console.WriteLine("OnCompleted"));
            using (source.Subscribe(obsvr))
            {
                Console.WriteLine("Press ENTER to unsubscribe...");
                Console.ReadLine();
            }
        }
    }
}
