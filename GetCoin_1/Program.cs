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

            //открываем файл для потока
            FileStream JsonFile = new FileStream(@"C:\Users\1\Desktop\New\helloJson.txt", FileMode.Open);
            //записывем в поток данные с файла
            StreamWriter JsonWriter = new StreamWriter(JsonFile);
            DataContractJsonSerializer newClass = new DataContractJsonSerializer(typeof(ArrayNewCoin));
            
            ArrayNewCoin beach = new ArrayNewCoin(5);
            
            Console.WriteLine(beach.items[3]);
            Console.WriteLine(beach.name); 
            beach.items[0] = 85;
            beach.items[1] = 5;
            beach.items[2] = 67;
            //beach.items[0].name = "Bitcoin";
            // beach.items[0].value = 10000;
            //beach.items[1].name = "Verge";
            // beach.items[1].value = 5;
           // Console.WriteLine(beach.items[2]);
            newClass.WriteObject(JsonFile, beach);
            JsonFile.Close();

            ArrayNewCoin afterJson = new ArrayNewCoin(5);
            FileStream ft = new FileStream(@"C:\Users\1\Desktop\New\helloJson.txt", FileMode.Open);

            
            afterJson=(ArrayNewCoin) newClass.ReadObject(ft); 
            Console.WriteLine(afterJson.items[2]);
            
            
            //allCoin.ReadObject(validJsonMemoryStream);

            Console.ReadLine();
        }
    }

    [DataContract]
    class ArrayNewCoin
    {   [DataMember]
        public int [] items { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int df { get; set; }
        public ArrayNewCoin(int n)
        {
            items = new int[n];

        }
    }

    [DataContract]
    class NewCoin
    { [DataMember]
       public string name { get; set; }
        [DataMember]
       public int value { get; set; }
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
