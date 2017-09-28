using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDAO
{
    public class Table
    {
        public string Name { get; set; }
        public List<TableColumn> Columns = new List<TableColumn>();
    }
}
