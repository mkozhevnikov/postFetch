using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PostFetcher.Model
{
    partial class DataBase
    {
        public DataBase() : this(ConfigurationManager.ConnectionStrings["post"].ConnectionString) {
            if (!DatabaseExists())
                CreateDatabase();
        }
    }
}
