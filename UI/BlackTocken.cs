using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace UI
{
    public struct TokenManager
    {
        public List<string> TokenList { get; set; }
        public List<DateTime> TimeList { get; set; }
    }
    public class TockenControl
    {
        private TokenManager BlackList;
        private const int TimeLive = 4;

        public void Logout(string token, DateTime createTime)
        {
            if (BlackList.TokenList == null || BlackList.TimeList == null)
            {
                BlackList.TokenList = new List<string>();
                BlackList.TimeList = new List<DateTime>();
            }
            BlackList.TokenList.Add(token);
            BlackList.TimeList.Add(createTime);
        }

        public void Update()
        {
            for (int i = 0; i < BlackList.TokenList.Count; i++)
            {
                if (BlackList.TimeList[i].AddHours(TimeLive) < DateTime.Now)
                {
                    BlackList.TokenList.Remove(BlackList.TokenList[i].ToString());
                    BlackList.TimeList.Remove(BlackList.TimeList[i]);
                    i--;
                }
            }
        }

        public IMemoryCache Save(IMemoryCache memoryCache)
        {
            memoryCache.Set("Blacklist", BlackList);
            return memoryCache;
        }

        public void Download(IMemoryCache memoryCache)
        {
            memoryCache.TryGetValue("Blacklist", out BlackList);
        }

        public bool IsInBlacklist(string tocken)
        {
            if (BlackList.TokenList != null)
                return BlackList.TokenList.Contains(tocken);
            return false;
        }
    }
}
