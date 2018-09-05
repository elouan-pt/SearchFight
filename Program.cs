using SearchFight.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            int begin = Environment.TickCount;
            AsyncRunner(args);
            Console.WriteLine($"Time: {(Environment.TickCount - begin)}");
        }

        private static async void AsyncRunner(string[] args)
        {
            ISearchEngineFactory factory = new WebScraperFactory();
            var engines = factory.CreateEngines();
            var result = new Result();
            List<Task> taskList = new List<Task>();
            foreach (var engine in engines)
            {
                foreach (var query in args)
                {
                    taskList.Add(engine.Send(query, result));
                }
            }
            await Task.WhenAll(taskList.ToArray());
            result.PrintResult();
        }
    }
}
