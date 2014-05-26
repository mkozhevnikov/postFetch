using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using PostFetcher.HtmlAgent;
using PostFetcher.Model;

namespace PostFetcher.Handler
{
    abstract class PageableSourceHandler : IHandler<Article> {
        protected DOMAgent Agent = new DOMAgent();

        public void Process(string firstPage)
        {
            var queue = new Queue<string>();
            queue.Enqueue(firstPage);
//            var counter = 0;
            while (queue.Count != 0) {
                var currentUrl = queue.Dequeue();
                var page = Agent.GetDOM(currentUrl);
                var processedPostCount = ProcessPage(page);
                if (processedPostCount == 0) return;
                foreach (var href in GetPagingLinks(page)) {
                    queue.Enqueue(href);
                }
            }
        }

        public abstract void Save(Article obj);
        public abstract bool IsProcessed(Article obj);

        protected abstract int ProcessPage(HtmlDocument page);

        protected abstract IEnumerable<string> GetPagingLinks(HtmlDocument page);
    }
}
