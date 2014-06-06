using System;
using System.Collections.Generic;
using System.Linq;
using PostFetcher.Handler;

namespace PostView {
    internal class HandlerFactory {
        /// <summary>
        /// Вызывает обработку веб страницы
        /// </summary>
        /// <typeparam name="T">Тип обработчика</typeparam>
        /// <typeparam name="TM">Тип обрабатываемой модели</typeparam>
        /// <param name="firstPage">Стартовая страница для обработки</param>
        public static void InvokeHandlerProcess<T, TM>(string firstPage) where T : IHandler<TM>, new() {
            new T().Process(firstPage);
        }

        /// <summary>
        /// Вызывает обработку веб страницы
        /// </summary>
        /// <typeparam name="TM">Тип обрабатываемой модели</typeparam>
        /// <param name="handlerType">Тип обработчика</param>
        /// <param name="firstPage">Стартовая страница для обработки</param>
        public static void Call<TM>(Type handlerType, string firstPage) {
            var info = typeof (HandlerFactory).GetMethod("InvokeHandlerProcess");
            info.MakeGenericMethod(handlerType, typeof (TM)).Invoke(null, new[] {firstPage});
        }

        /// <summary>
        /// Создает набор типов, которые реализуют интерфейс IHandler
        /// </summary>
        /// <typeparam name="TM">Тип обрабатываемой модели</typeparam>
        public static IEnumerable<Type> GetHandlerTypes<TM>() {
            var type = typeof (IHandler<TM>);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface);
        }
    }
}
