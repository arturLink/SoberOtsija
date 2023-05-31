using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

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
