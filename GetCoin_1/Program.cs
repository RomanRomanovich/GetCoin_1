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
            string validJson = "{items:"+ noValidJson.ReadToEnd() + "}"; // создаем валидный JSON 
            Console.WriteLine(validJson);

           
            DataContractJsonSerializer coinStream = new DataContractJsonSerializer(typeof(string));
            AllCoin1 allCoin = new AllCoin1();
          //  string str = (string)coinStream.ReadObject(stream);
            //allCoin = (AllCoin1)coinStream.ReadObject(stream);
           // Console.WriteLine(allCoin.co[1].rank);
            Console.ReadLine();
        }
    }




    public class AllCoin1
    {
        public Coin1[] co { get; set; }
    }

    public class Coin1
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




    public class InfoCoin
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Coin[] result { get; set; }
    }

    public class Coin
    {
        public string MarketName { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Volume { get; set; }
        public float Last { get; set; }
        public float BaseVolume { get; set; }
        public string TimeStamp { get; set; }
        public float Bid { get; set; }
        public float Ask { get; set; }
        public int OpenBuyOrders { get; set; }
        public int OpenSellOrders { get; set; }
        public float PrevDay { get; set; }
        public string Created { get; set; }
    }


   



}
