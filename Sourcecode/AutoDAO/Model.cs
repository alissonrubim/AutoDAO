using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDAO
{
    public class Model<T>
    {
        public string Table { get; set; }

        public void Insert(T obj)
        {
            /*List<string> columns = new List<string>();
            List<string> columnsKeys = new List<string>();
            List<DatabaseParameter> values = new List<DatabaseParameter>();
            foreach (TableColumn tableColumn in Columns)
            {
                columns.Add(tableColumn.Name);
                columnsKeys.Add("@" + field.ObjectProperty);
                values.Add(new DatabaseParameter(field.ObjectProperty, obj.GetType().GetProperty(field.ObjectProperty).GetValue(obj, null)));
            }

            this.ExecuteCommand($"INSERT INTO {Table}({String.Join(",", columns)}) VALUES({String.Join(",", columnsKeys)})", values.ToArray());*/
        }
    }
}
