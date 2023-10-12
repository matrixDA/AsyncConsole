using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncConsole
{
    public class Async
    {
        public int sum(int a, int b)
        {
            return a + b;
        }
        public async Task<int> sumAsync(int a, int b)
        {
            return await Task.Run(() => a + b);
        }

        public async Task ReadBook(string file)
        {
            var lines = await Task.FromResult(File.ReadAllLinesAsync(file));
            var linesWithoutPunctuation = lines.Result.Where(x => x != string.Empty)
                
                .AsParallel()
                    .Select(x => x.ToLower().Trim().Replace(",", "")
                    .Replace(":", "").Replace(".", "").Replace("*", ""));

            var arrayOfWords = linesWithoutPunctuation.SelectMany(x => x.Split(" "));

            Dictionary<string, int> wordDic = new Dictionary<string, int>();

            arrayOfWords.ToList().ForEach(x =>
            {
                if (wordDic.ContainsKey(x))
                {
                    wordDic[x]++;
                }
                else
                {
                    wordDic.Add(x, 1);
                }
            });

            var top10 = wordDic.Where(x => !string.IsNullOrWhiteSpace(x.Key))
                .OrderByDescending(x => x.Value).Take(10);

            foreach (var word in top10) 
            { 
                Console.WriteLine(word.Key + " - " + word.Value);
            }
        }
    }
}
