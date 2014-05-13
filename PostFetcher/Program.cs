using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace PostFetcher
{
    class Program
    {
        private const string E1Resume = "http://rabota.e1.ru/resume";

        static void Main(string[] args) {
//            var web = new HtmlWeb();
//            var doc = web.Load(E1Resume);
            var doc = new HtmlDocument();
            doc.LoadHtml(GetRequest(E1Resume));
            
            var nodeCollection = doc.DocumentNode.SelectNodes("//a[@class='ra-elements-list__title__link']");
            if (nodeCollection != null) {
                foreach (var node in nodeCollection) {
                    Console.WriteLine(node.GetAttributeValue("href", ""));
                }
            }
        }

        public static string GetRequest(string url)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, Encoding.GetEncoding(httpWebResponse.CharacterSet)))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}
