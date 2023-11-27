using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Database
{
    public interface IPath
    {

        protected const string APP_DB_FILENAME = "database4.db";
        protected const string APP_NAME = "TicTacToe";
        protected const string APP_DB_FOLDER = "Databases";

        string GetDatabasePath(string appName = APP_NAME, string appDbFolder = APP_DB_FOLDER, string filename = APP_DB_FILENAME);

        string GetDatabaseFolder(string appName = APP_NAME, string appDbFolder = APP_DB_FOLDER);

        void DeleteFile(string path);
    }
}
