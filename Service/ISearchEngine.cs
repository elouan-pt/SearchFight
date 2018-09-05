using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Service
{
    interface ISearchEngine
    {
        string Name { get; }
        Task Send(string query, Result result);
    }
}
