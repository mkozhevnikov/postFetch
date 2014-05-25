using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace PostFetcher.HtmlAgent
{
    public class DOMAgent : Agent
    {
        public HtmlDocument GetDOM(string url)
        {
//            var web = new HtmlWeb();
//            var doc = web.Load(E1Resume);
            var doc = new HtmlDocument();
            doc.LoadHtml(LoadPage(url));
            return doc;
        }
    }
}
