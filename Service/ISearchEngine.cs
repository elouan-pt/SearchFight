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
        Response Send(string query);
    }
}
