using Android.App;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using EXAMENI_LRAD.Models;
using System.Threading.Tasks;

namespace EXAMENI_LRAD.Controller
{
   public class ContactosController
    {
        readonly SQLiteAsyncConnection connection;

        public ContactosController(string dpath)
        {
            connection = new SQLiteAsyncConnection(dpath);
            connection.CreateTableAsync<ContactosModel>().Wait();
        }

        public Task<int> saveContacto(ContactosModel contactosModel)
        {
            if (contactosModel.id != 0)
                return connection.UpdateAsync(contactosModel);
            else
                return connection.InsertAsync(contactosModel);
        }

        public Task<List<ContactosModel>> GetListContactos()
        {
            return connection.Table<ContactosModel>().ToListAsync();
        }

        public Task<ContactosModel> GetContactos(int pid)
        {
            return connection.Table<ContactosModel>()
                .Where(a => a.id == pid)
                .FirstOrDefaultAsync();
        }

        public Task DeleteContacto(ContactosModel contactosModel)
        {
            return connection.DeleteAsync(contactosModel);
        }

    }
}

