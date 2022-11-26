using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using GalenoSYS.Models;
using System.Threading.Tasks;
using GalenoSYS.Ws;

namespace GalenoSYS.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath) 
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<t_usuario>().Wait();
        }

        public Task<int> SaveUsuariosAsync(SqlLogin loginusuario)
        {
            if (loginusuario.usr_id == 0)
            {
                return db.InsertAsync(loginusuario);
            }
            else
            {
                return null;
            }
        
        
        
        }
    }
}
