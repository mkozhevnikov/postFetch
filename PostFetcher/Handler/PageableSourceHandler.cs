using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using PostFetcher.HtmlAgent;

namespace PostFetcher.Handler
{
    abstract class PageableSourceHandler : IHandler
    {
        public void Process(DOMAgent agent, string firstPage) {
            var queue = new Queue<string>();
            queue.Enqueue(firstPage);
//            var counter = 0;
            while (queue.Count != 0) {
                var currentUrl = queue.Dequeue();
                var page = agent.GetDOM(currentUrl);
                var processedPostCount = ProcessPage(page);
                if (processedPostCount == 0) return;
                foreach (var href in GetPagingLinks(page)) {
                    queue.Enqueue(href);
                }
            }
        }

        protected abstract int ProcessPage(HtmlDocument page);

        protected abstract IEnumerable<string> GetPagingLinks(HtmlDocument page);
    }
}
