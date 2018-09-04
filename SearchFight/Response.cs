using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight
{
    class Response
    {
        public long Count { get; set; }
        public string Query { get; set; }
        public string Source { get; set; }

        public Response(long count, string query, string source)
        {
            this.Count = count;
            this.Query = query;
            this.Source = source;
        }
    }
}
