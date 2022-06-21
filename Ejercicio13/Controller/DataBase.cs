using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PM022PP0122.Models;
using SQLite;

namespace PM022PP0122.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;
        /*Constructor de clase*/
        
        public DataBase(string dbpath) {
            dbase = new SQLiteAsyncConnection(dbpath);
            //creacion de las tablas de la base de datos
            dbase.CreateTableAsync<Persona>(); //creando tabla de empleados

            
        }

        #region Operaciones

        //CRUD -CREATE  -READ  -UPDATE  -DELETE


        //Create
        public Task<int> EmpleSave(Persona emple)
        {
            if(emple.id != 0)
            {
                return dbase.UpdateAsync(emple);
            }
            else
            {
                return dbase.InsertAsync(emple);
            }
        }

        //Read
        public Task<List<Persona>> ObtenerListaEmple()
        {
            return dbase.Table<Persona>().ToListAsync();
        }

        //Read v2
        public Task<Persona> ObtenerEmple(int pid)
        {
            return dbase.Table<Persona>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        //Delete

        public Task<int> EmpleDelete(Persona emple)
        {
            return dbase.DeleteAsync(emple);
        }

        #endregion Operaciones

       

    }
}
