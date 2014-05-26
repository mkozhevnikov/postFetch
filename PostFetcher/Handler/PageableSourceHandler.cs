using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using PostFetcher.HtmlAgent;
using PostFetcher.Model;

namespace PostFetcher.Handler
{
    abstract class PageableSourceHandler : IHandler<Model.Resume> {
        protected DOMAgent Agent = new DOMAgent();

        public void Process(string firstPage)
        {
            var queue = new Queue<string>();
            queue.Enqueue(firstPage);
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

        public abstract void Save(Model.Resume obj);
        
        public abstract bool IsProcessed(Model.Resume obj);

        /// <summary>
        /// Обрабатывает страницу с разными резюме
        /// </summary>
        /// <param name="page"></param>
        /// <returns>Количество обработанных резюме</returns>
        protected abstract int ProcessPage(HtmlDocument page);

        /// <summary>
        /// Извлекает paging ссылки 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        protected abstract IEnumerable<string> GetPagingLinks(HtmlDocument page);
    }
}
