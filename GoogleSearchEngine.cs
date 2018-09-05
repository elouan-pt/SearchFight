using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SearchFight
{
    class GoogleSearchEngine : ISearchEngine
    {
        public string Name => "Google";

        public Response Send(string query)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36");
            
            string url = "https://www.google.com/search";
            string webData = client.DownloadString($"{url}?q={query}&hl=en");
            string pattern = @"\<div[^\>]+id=""resultStats""[^\>]*\>About ([\d\,\.]+) results";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(webData);
            long count = 0;
            if (match.Success)
            {
                count = long.Parse(match.Groups[1].Value.Replace(",", "").Replace(".", ""));
            }
            return new Response(count, query, Name);
        }
    }
}
