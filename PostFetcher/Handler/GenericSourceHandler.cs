using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace PostFetcher.Handler
{
    abstract class GenericSourceHandler : PageableSourceHandler
    {
        protected override int ProcessPage(HtmlDocument page) {
            throw new NotImplementedException();
        }

        protected override IEnumerable<string> GetPagingLinks(HtmlDocument page) {
            throw new NotImplementedException();
        }
    }
}
