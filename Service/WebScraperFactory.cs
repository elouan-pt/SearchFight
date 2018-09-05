using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Service
{
    class WebScraperFactory : ISearchEngineFactory
    {
        public ISearchEngine[] CreateEngines()
        {
            ISearchEngine[] engines = { new GoogleSearchEngine(), new BingSearchEngine() };
            return engines;
        }
    }
}
