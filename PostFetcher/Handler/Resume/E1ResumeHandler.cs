using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using PostFetcher.Model;

namespace PostFetcher.Handler.Resume
{
    class E1ResumeHandler : GenericSourceHandler    
    {
        private const string RabotaE1 = "http://rabota.e1.ru";
        private const string E1Resume = RabotaE1 + "/resume";

        protected override int ProcessPage(HtmlDocument page) {
            var doc = Agent.GetDOM(E1Resume);
            var nodeCollection = doc.DocumentNode.SelectNodes("//a[@class='ra-elements-list__title__link']");
            int count = 0;
            if (nodeCollection != null) {
                foreach (var node in nodeCollection) {
                    var href = node.GetAttributeValue("href", "");
                    var resume = new Model.Resume {Link = href};
                    if (IsProcessed(resume)) continue;
                    Console.WriteLine(href);
                    ProcessResumePage(ref resume);
                    Save(resume);
                    count++;
                }
            }
            return count;
        }

        protected override IEnumerable<string> GetPagingLinks(HtmlDocument page) {
            throw new NotImplementedException();
        }

        private void ProcessResumePage(ref Model.Resume resume) {
            var document = Agent.GetDOM(RabotaE1 + resume);
            //parse page
            Save(resume);
        }
    }
}
