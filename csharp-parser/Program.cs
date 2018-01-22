using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateStr = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
            dateStr = dateStr.Replace("/", "-").Replace(":","-").Replace(" ", "-");
            string csvFileName = "xxxCSVFormatted-" + dateStr + ".csv";
            string destDir = @"e:\aaa\";
            string csvFileFullPath = destDir + csvFileName;
            string jsonFileName = "xxxJSONFormatted-" + dateStr + ".json";
            string jsonFileFullPath = destDir + jsonFileName;
            string text = Properties.Resources.TextFile1.ToString();
            System.Console.WriteLine("Properties.Resources", Properties.Resources.TextFile1);
            //string text = System.IO.File.ReadAllText(@"Log.txt");

            // Display the file contents to the console. Variable text is a string.
           // System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = Properties.Resources.TextFile1.Split('\n');
            //string[] lines = System.IO.File.ReadAllLines(@"e:\aaa\xxx.txt");
            string[] newLines1 = new string[lines.Length+1];
            
            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            string header = "\"Date\",  \"vendor\",  \"product\",  \"product_version\",  \"action\",  \"severity\",  \"category\",  \"user\",  \"src_host\",  \"src_port\",  \"dst_host\",  \"dst_ip\",  \"dst_port\",  \"bytes_out\",  \"bytes_in\",  \"http_response\",  \"http_method\",  \"http_content_type\",  \"http_user_agent\",  \"http_proxy_status_code\",  \"reason\",  \"disposition\",  \"policy\",  \"role\",  \"duration\",  \"url\"";
            newLines1[0] = header;
            Console.WriteLine(newLines1[0]);
            //foreach (string line in lines)
            int ll = lines.Length;
            for(int i=0; i < ll; i++)
            {
                // Use a tab to indent each line of the file.
                string line = "\""+ lines[i];
                line = line
                    .Replace(" vendor=", "\", \"")
                    .Replace(" product=", "\", \"")
                    .Replace(" product_version=", "\", \"")
                    .Replace(" action=", "\", \"")
                    .Replace(" severity=", "\", ")
                    .Replace(" category=", ", ")
                    .Replace(" user=", ", \"")
                    .Replace(" src_host=", "\", \"")
                    .Replace(" src_port=", "\", ")
                    .Replace(" dst_host=", ", \"")
                    .Replace(" dst_ip=", "\", \"")
                    .Replace(" dst_port=", "\", ")
                    .Replace(" bytes_out=", ", ")
                    .Replace(" bytes_in=", ", ")
                    .Replace(" http_response=", ", ")
                    .Replace(" http_method=", ", \"")
                    .Replace(" http_content_type=", "\", \"")
                    .Replace(" http_user_agent=", "\", \"")
                    .Replace(" http_proxy_status_code=", "\", ")
                    .Replace(" reason=", ", \"")
                    .Replace(" disposition=", "\", ")
                    .Replace(" policy=", ", \"")
                    .Replace(" role=", "\", ")
                    .Replace(" duration=", ", ")
                    .Replace(" url=", ", \"");
                newLines1[i+1] = line + "\"";
                Console.WriteLine(newLines1[i+1]);
            }
            
            System.IO.File.WriteAllLines(csvFileFullPath, newLines1);
            // Keep the console window open in debug mode.
            string[] newLinesJson = new string[lines.Length + 2];
            newLinesJson[0] = "[ ";
            int j = 0;
            int length = lines.Length;
            for (j=0; j < length; j++)
            {
                string line = "{ \"Date\" : \"" + lines[j];
                line = line
                .Replace(" vendor=", "\", \"vendor\" : \"")
                .Replace(" product=", "\", \"product\" : \"")
                .Replace(" product_version=", "\", \"product_version\" : \"")
                .Replace(" action=", "\", \"action\" : \"")
                .Replace(" severity=", "\", \"severity\" : ")
                .Replace(" category=", ", \"category\" : ")
                .Replace(" user=", ", \"user\" : \"")
                .Replace(" src_host=", "\", \"src_host\" : \"")
                .Replace(" src_port=", "\", \"src_port\" : ")
                .Replace(" dst_host=", ", \"dst_host\" : \"")
                .Replace(" dst_ip=", "\", \"dst_ip\" : \"")
                .Replace(" dst_port=", "\", \"dst_port\" : ")
                .Replace(" bytes_out=", ", \"bytes_out\" : ")
                .Replace(" bytes_in=", ", \"bytes_in\" : ")
                .Replace(" http_response=", ", \"http_response\" : ")
                .Replace(" http_method=", ", \"http_method\" : \"")
                .Replace(" http_content_type=", "\", \"http_content_type\" : \"")
                .Replace(" http_user_agent=", "\", \"http_user_agent\" : \"")
                .Replace(" http_proxy_status_code=", "\", \"http_proxy_status_code\" : ")
                .Replace(" reason=", ", \"reason\" : \"")
                .Replace(" disposition=", "\", \"disposition\" : ")
                .Replace(" policy=", ", \"policy\" : \"")
                .Replace(" role=", "\", \"role\" : ")
                .Replace(" duration=", ", \"duration\" : ")
                .Replace(" url=", ", \"url\" : \"");
                newLinesJson[j+1] = line + "\" }";
                if (j < length - 1) { newLinesJson[j + 1] += ","; }
                    Console.WriteLine(newLinesJson[j+1]);
            }
            newLinesJson[length+1] = " ]";
            System.IO.File.WriteAllLines(jsonFileFullPath, newLinesJson);
            Console.WriteLine("JSON Reading started. press any key to start.......");
            System.Console.ReadKey();
            ReadJsonFile(jsonFileFullPath);
            Console.WriteLine("JSON Reading ended");
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }
        public class Item
        {
            public string Date;
            public string vendor;
            public string product;
            public string product_version;
            public string action;
            public int severity;
            public int category;
            public string user;
            public string src_host;
            public int src_port;
            public string dst_host;
            public string dst_ip;
            public int dst_port;
            public int bytes_out;
            public int bytes_in;
            public int http_response;
            public string http_method;
            public string http_content_type;
            public string http_user_agent;
            public int http_proxy_status_code;
            public string reason;
            public int disposition;
            public string policy;
            public int role;
            public int duration;
            public string url;

        }
        static void ReadJsonFile(string fileName)
        {
            using (System.IO.StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                Console.WriteLine("JSON Reading dynamic style started. presss any key to continue.......");
                System.Console.ReadKey();
                LoadJson(json);
                Console.WriteLine("JSON Reading dynamic style ended");
                Console.WriteLine("JSON Reading staic-deterministic style started. press any key to continue.......");
                System.Console.ReadKey();
                LoadJsonDeterministic(json);
                Console.WriteLine("JSON Reading  staic-deterministic style started");
            }

        }
        static void LoadJson(string json)
        {
            dynamic array = JsonConvert.DeserializeObject(json);
            foreach (var item in array)
            {
                Console.WriteLine("{0} {1}", item.src_host, item.dst_ip);
            }
        
        }
        static void LoadJsonDeterministic(string json)
        {


            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
            
            foreach (var item in items)
            {
                Console.WriteLine("{0} {1}", item.src_host, item.dst_ip);
            }

        }
    }
}
