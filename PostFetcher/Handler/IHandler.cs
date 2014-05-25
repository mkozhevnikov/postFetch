using PostFetcher.HtmlAgent;

namespace PostFetcher.Handler {
    internal interface IHandler<in T> {
        void Process(string firstPage);
        void Save(T obj);
//        void Update(M obj);
        bool IsProcessed(T obj);
    }
}