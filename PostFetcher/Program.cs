using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using PostFetcher.Handler.News;

namespace PostFetcher
{
    class Program
    {
        private static void Main(string[] args) {
            new E1NewsHandler().Process();
        }
    }
}
