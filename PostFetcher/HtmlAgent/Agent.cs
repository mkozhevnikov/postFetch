using System;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace PostFetcher.HtmlAgent
{
    class Agent
    {
        public string LoadPage(string url) {
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
