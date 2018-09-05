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
            ISearchEngineFactory factory = new WebScraperFactory();
            var engines = factory.CreateEngines();
            var result = new Result();
            foreach (var engine in engines)
            {
                foreach (var query in args)
                {
                    var response = engine.Send(query);
                    result.Aggregate(response);
                }
            }
            result.PrintResult();
        }
    }
}
