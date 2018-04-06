using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GetCoin_1
{
    class Program
    {
        static void Main(string[] args)
        {

            string web = "https://api.coinmarketcap.com/v1/ticker/?limit=2";
            WebRequest webRequest = WebRequest.Create(web);
            Stream stream = webRequest.GetResponse().GetResponseStream();
            StreamReader noValidJson = new StreamReader(stream); // получаем не валидный JSON в текстовой кодировке 
            string validJson = "{\"items\":" + noValidJson.ReadToEnd() + "}"; // создаем валидный JSON 
            
            
            //Console.WriteLine(validJson.Replace("\n","").Replace(" ",""));
            string validJson1 = validJson.Replace("\n", "").Replace(" ", "");
            //помещаем строку в поток
            Console.WriteLine(validJson1);



            MemoryStream validJsonMemoryStream = new MemoryStream();
            StreamWriter validJsonWriter = new StreamWriter(validJsonMemoryStream);

            validJsonWriter.Write(validJson1);
            DataContractJsonSerializer allCoin = new DataContractJsonSerializer(typeof(CoinList));


            allCoin.ReadObject(validJsonMemoryStream);

            Console.ReadLine();
        }
    }



    public class CoinList
    {
        public Coin[] items { get; set; }
    }

    public class Coin
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string rank { get; set; }
        public string price_usd { get; set; }
        public string price_btc { get; set; }
        public string _24h_volume_usd { get; set; }
        public string market_cap_usd { get; set; }
        public string available_supply { get; set; }
        public string total_supply { get; set; }
        public string max_supply { get; set; }
        public string percent_change_1h { get; set; }
        public string percent_change_24h { get; set; }
        public string percent_change_7d { get; set; }
        public string last_updated { get; set; }
    }









}
