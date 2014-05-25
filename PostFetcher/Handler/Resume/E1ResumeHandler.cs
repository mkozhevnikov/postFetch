using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace PostFetcher.Handler.Resume
{
    class E1ResumeHandler : GenericSourceHandler    
    {
        private const string RabotaE1 = "http://rabota.e1.ru";
        private const string E1Resume = RabotaE1 + "/resume";
        private static HashSet<string> _processed = new HashSet<string>();

        public override void Save(Article obj) {
            throw new NotImplementedException();
        }

        public override bool IsProcessed(Article obj) {
            throw new NotImplementedException();
        }

        protected override int ProcessPage(HtmlDocument page) {
            var doc = Agent.GetDOM(E1Resume);
            var nodeCollection = doc.DocumentNode.SelectNodes("//a[@class='ra-elements-list__title__link']");
            int count = 0;
            if (nodeCollection != null) {
                foreach (var node in nodeCollection) {
                    var href = node.GetAttributeValue("href", "");
                    Console.WriteLine(href);
                    ProcessResumePage(href, ref count);
                }
            }
            return count;
        }

        private void ProcessResumePage(string resumeLink, ref int count) {
            var document = Agent.GetDOM(RabotaE1 + resumeLink);
            _processed.Add(resumeLink);
        }
    }
}
