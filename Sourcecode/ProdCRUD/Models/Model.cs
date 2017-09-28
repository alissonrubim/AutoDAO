using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCRUD.Models
{
    public class Model<T>: Database
    {

        /* public class ModelField
        {
             public string ColumnName { get; set; }
             public string ObjectProperty { get; set; }
             public bool IsKey { get; set; }
         }*/

        /* public string Table;
         public List<ModelField> Columns;


         public void AddColumns(string name, bool isKey = false)
        {

        }
         public void Insert2(T obj)
         {
            List<string> columns = new List<string>();
            List<string> columnsKeys = new List<string>();
            List<DatabaseParameter> values = new List<DatabaseParameter>();
            foreach (ModelField field in Columns)
            {
                columns.Add(field.ColumnName);
                columnsKeys.Add("@" + field.ObjectProperty);
                values.Add(new DatabaseParameter(field.ObjectProperty, obj.GetType().GetProperty(field.ObjectProperty).GetValue(obj, null)));
            }

            this.ExecuteCommand($"INSERT INTO {Table}({String.Join(",",columns)}) VALUES({String.Join(",", columnsKeys)})", values.ToArray());
         }

         public void Update2(T obj)
         {
            List<string> columns = new List<string>();
            List<DatabaseParameter> values = new List<DatabaseParameter>();
            foreach (ModelField field in Columns)
            {
                columns.Add($"{field.ColumnName} = @{field.ObjectProperty}");
                values.Add(new DatabaseParameter(field.ObjectProperty, obj.GetType().GetProperty(field.ObjectProperty).GetValue(obj, null)));
            }

            this.ExecuteCommand($"UPDATE {Table} SET {String.Join(",", columns)} WHERE ", values.ToArray());

        }

      /*  public void Remove(T obj)
         {

         }

         public T GetByKey(int keyvalue)
         {
             return default(T);
         }*/


    }
}
