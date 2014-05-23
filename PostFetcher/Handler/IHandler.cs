using PostFetcher.HtmlAgent;

namespace PostFetcher.Handler {
    internal interface IHandler {
        void Process(DOMAgent agent, string firstPage);
    }
}