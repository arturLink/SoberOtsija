using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoberOtsija.Models
{
    [Table("salvSobrad")]
    public class salvSobrad
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Trait1 { get; set; }
        public string Trait2 { get; set; }
        public string Trait3 { get; set; }
    }
}
