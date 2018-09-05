﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SearchFight
{
    class BingSearchEngine : ISearchEngine
    {
        public string Name => "MSN Search";

        public Response Send(string query)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            string url = "https://www.bing.com/search";
            string webData = client.DownloadString($"{url}?q={query}");
            string pattern = @"\<span[^\>]+class=""sb_count""[^\>]*\>([\d\.\,]+)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(webData);
            long count = 0;
            if (match.Success)
            {
                count = long.Parse(match.Groups[1].Value.Replace(",", ""));
            }
            return new Response(count, query, Name);
        }
    }
}