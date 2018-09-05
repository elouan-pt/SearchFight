using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Service
{
    class Result
    {
        private List<Response> results = new List<Response>();
        private Dictionary<string, long> dictionary = new Dictionary<string, long>();

        public void Aggregate(Response response)
        {
            results.Add(response);
            if (dictionary.ContainsKey(response.Query))
            {
                long total = dictionary[response.Query];
                dictionary.Remove(response.Query);
                dictionary.Add(response.Query, total + response.Count);
            } else
            {
                dictionary.Add(response.Query, response.Count);
            }
        }

        public void PrintResult()
        {
            foreach (var key in dictionary.Keys)
            {
                StringBuilder sb = new StringBuilder(key);
                sb.Append(": ");
                results.FindAll(r => r.Query.Equals(key)).ForEach(i => {
                    sb.Append(i.Source);
                    sb.Append(": ");
                    sb.Append(i.Count);
                    sb.Append(" ");
                });
                Console.WriteLine(sb);
            }

            var groupedResult = from r in results
                          group r by r.Source;

            foreach (var group in groupedResult)
            {
                List<Response> list = group.OrderBy(r => r.Count).ToList();
                Response winner = list.Last();

                StringBuilder sb = new StringBuilder(group.Key);
                sb.Append(" ");
                sb.Append("winner: ");
                sb.Append(winner.Query);
                Console.WriteLine(sb);
            }

            var totalWinner = String.Empty;
            long winnerValue = 0;
            foreach (var result in dictionary)
            {
                if (result.Value > winnerValue)
                {
                    winnerValue = result.Value;
                    totalWinner = result.Key;
                }
            }
            Console.WriteLine($"Total winner: {totalWinner}");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
