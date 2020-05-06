using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.TestSQLite.Models {
    public class ItemSQLite {

        [PrimaryKey]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }

    }

}
