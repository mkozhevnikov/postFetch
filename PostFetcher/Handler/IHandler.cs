using PostFetcher.HtmlAgent;

namespace PostFetcher.Handler {
    /// <summary>
    /// Универсальный интерфейс парсера
    /// </summary>
    /// <typeparam name="T">Тип обрабатываемого объекта</typeparam>
    public interface IHandler<in T> {
        
        /// <summary>
        /// Загружает и парсит страницу
        /// </summary>
        /// <param name="firstPage">Стартовая страница загрузки</param>
        void Process(string firstPage);
        
        /// <summary>
        /// Сохраняет объект в базу данных
        /// </summary>
        void Save(T obj);
//        void Update(M obj);

        /// <returns>Проверяет нужно ли обрабатывать и сохранять объект</returns>
        bool IsProcessed(T obj);
    }
}