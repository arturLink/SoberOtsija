using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace SoberOtsija.Models
{
    public class SoberRepository
    {
        SQLiteConnection database;
        public SoberRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Sober>();
        }
        public IEnumerable<Sober> GetChosenItem(string trait1, string trait2, string trait3)
        {
            return database.Query<Sober>("SELECT * FROM Sober WHERE Trait1 IN (?,?,?) OR Trait2 IN (?,?,?) OR Trait3 IN (?,?,?)",trait1,trait2,trait3,trait1,trait2,trait3,trait1,trait2,trait3).ToList();
        }
        public IEnumerable<Sober> GetItems()
        {
            return database.Table<Sober>().ToList();
        }
        public Sober GetItem(int id)
        {
            return database.Get<Sober>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Sober>(id);
        }
        public int SaveItem(Sober item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
