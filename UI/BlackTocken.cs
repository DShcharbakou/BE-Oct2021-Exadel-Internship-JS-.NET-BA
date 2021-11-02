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

        public TockenControl()
        {

            if (System.IO.File.Exists("blacklist.json"))
            {
                Download();
            }
            else
            {
                BlackList = new TokenManager();
                BlackList.TokenList = new List<string>();
                BlackList.TimeList = new List<DateTime>();
                Save();
            }
            
        }

        public void Logout(string token, DateTime createTime)
        {
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

        public async void Save()
        {
            using (FileStream fs = new FileStream("blacklist.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<TokenManager>(fs, BlackList);
                fs.Close();
            }
        }

        public async void Download()
        {
            using(FileStream fs = new FileStream("blacklist.json", FileMode.OpenOrCreate))
            {
                BlackList = await JsonSerializer.DeserializeAsync<TokenManager>(fs);
                fs.Close();
            }
        }

        public bool IsInBlacklist(string tocken)
        {
            return BlackList.TokenList.Contains(tocken);
        }
    }
}
