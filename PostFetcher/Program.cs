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
        private const string RabotaE1 = "http://rabota.e1.ru";
        private const string E1Resume = RabotaE1 + "/resume";
        private static HashSet<string> _processed = new HashSet<string>();

        static void Main(string[] args) {
            var doc = GetDOM(E1Resume);
            var nodeCollection = doc.DocumentNode.SelectNodes("//a[@class='ra-elements-list__title__link']");
            if (nodeCollection != null) {
                foreach (var node in nodeCollection) {
                    var href = node.GetAttributeValue("href", "");
                    Console.WriteLine(href);
                    ProcessResumePage(href);
                }
            }
        }

        public static void ProcessResumePage(string resumeLink) {
            var document = GetDOM(RabotaE1 + resumeLink);
            _processed.Add(resumeLink);
        }

        public static HtmlDocument GetDOM(string url) {
//            var web = new HtmlWeb();
//            var doc = web.Load(E1Resume);
            var doc = new HtmlDocument();
            doc.LoadHtml(LoadPage(E1Resume));
            return doc;
        }

        public static string LoadPage(string url) {
            try {
                var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
                using (var httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse()) {
                    using (var stream = httpWebResponse.GetResponseStream()) {
                        using (var reader = new StreamReader(stream, Encoding.GetEncoding(httpWebResponse.CharacterSet))
                            ) {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch {
                return String.Empty;
            }
        }
    }
}
