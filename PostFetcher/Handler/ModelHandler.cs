using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace PostFetcher.Handler
{
    public abstract class ModelHandler<T> : IHandler<T> where T : class {
        protected readonly DataBase db = new DataBase(ConfigurationManager.ConnectionStrings["post"].ConnectionString);
        
        public abstract void Process(string firstPage);
        
        public void Save(T obj) {
            db.GetTable<T>().InsertOnSubmit(obj);
            try {
//                db.Log = Console.Out;
                db.SubmitChanges();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public abstract bool IsProcessed(T obj);
    }
}
