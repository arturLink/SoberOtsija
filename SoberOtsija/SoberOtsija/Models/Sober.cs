﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SoberOtsija.Models
{
    [Table("Sober")]
    public class Sober
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
