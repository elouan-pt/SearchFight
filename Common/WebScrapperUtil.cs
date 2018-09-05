using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SearchFight.Common
{
    class WebScrapperUtil
    {
        public static long GetResultCount(string pattern, string webData)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(webData);
            long count = 0;
            if (match.Success)
            {
                count = long.Parse(match.Groups[1].Value.Replace(",", "").Replace(".", ""));
            }
            return count;
        }
    }
}
