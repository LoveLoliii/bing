using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bing
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = GetInputString("请输入查询天数：");
            string mkt = GetInputString("请输入国家代码：");
            string url = "http://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=" + day + "&mkt=" + mkt;
            string content = GetHttpData(url);
            Console.WriteLine("查询结果：" + content);
            

        }

        public static string GetInputString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public static string GetHttpData(string uri)
        {
            Uri url = new Uri(uri);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            reader.Close();
            stream.Close();
            return result;
        }
    }
}
