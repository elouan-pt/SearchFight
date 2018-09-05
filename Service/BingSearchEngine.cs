using SearchFight.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Service
{
    class BingSearchEngine : ISearchEngine
    {
        public string Name => "MSN Search";

        public async Task Send(string query, Result result)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36");

            string url = "https://www.bing.com/search";
            string webData = client.DownloadString($"{url}?q={query}");
            string pattern = @"\<span[^\>]+class=""sb_count""[^\>]*\>([\d\.\,]+)";
            long count = WebScrapperUtil.GetResultCount(pattern, webData);
            result.Aggregate(new Response(count, query, Name));
        }
    }
}
