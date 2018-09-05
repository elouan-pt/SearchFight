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
            AsyncRunner(args);
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
