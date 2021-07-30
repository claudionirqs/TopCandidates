using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopCandidates
{
    class GlobalVar
    {

        private static string caminho = "";
        private static SQLiteConnection conn;

        public static string databasePath
        {
            get { return caminho; }
            set { caminho = value; }
        }

        public static SQLiteConnection dataBase
        {
            get { return conn; }
            set { conn = value; }
        }

        public static string apiPath = "https://app.ifs.aero/EternalBlue/api/";
    }
}
