using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using PostFetcher.HtmlAgent;

namespace PostFetcher.Handler
{
    abstract class GenericSourceHandler : PageableSourceHandler
    {
        protected static HashSet<string> _processed = new HashSet<string>();

        public override void Save(Model.Resume obj) {
            _processed.Add(obj.Link);
        }

        public override bool IsProcessed(Model.Resume obj) {
            return _processed.Contains(obj.Link);
        }
    }
}
