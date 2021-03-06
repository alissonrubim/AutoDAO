﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCRUD.Models
{
    public class Database
    {
        public class DatabaseParameter
        {
            public string Name { get; set; }
            public object Value { get; set; }

            public DatabaseParameter(string name, object value)
            {
                this.Name = name;
                this.Value = value;
            }
        }

        public static string ConnectionString;

        private MySqlConnection connection;

        public void OpenConnection()
        {
            if(connection == null)
            {
                if (ConnectionString != null)
                {
                    connection = new MySqlConnection(ConnectionString);
                    connection.Open();
                }
                else
                {
                    throw new Exception("ConnectionString can not be null");
                }
            }
        }

        public void CloseConnection()
        {
            if(connection != null)
            {
                connection.Close();
                connection = null;
            }
        }

        public void ExecuteCommand(string query)
        {
            this.ExecuteCommand(query, null);
        }

        public MySqlDataReader ExecuteReader(string query)
        {
            return this.ExecuteReader(query, null);
        }

        public void ExecuteCommand(string query, DatabaseParameter[] parameters)
        {
            if (connection == null)
                this.OpenConnection();
            prepareCmd(query, parameters).ExecuteNonQuery();
            this.CloseConnection();
        }

        public MySqlDataReader ExecuteReader(string query, DatabaseParameter[] parameters)
        {
            if (connection == null)
                this.OpenConnection();
            MySqlDataReader reader =  prepareCmd(query, parameters).ExecuteReader();
            this.CloseConnection();
            return reader;
        }

        private MySqlCommand prepareCmd(string query, DatabaseParameter[] parameters)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            if(parameters != null)
                foreach (DatabaseParameter param in parameters)
                    cmd.Parameters.Add(new MySqlParameter("@" + param.Name, param.Value));
            return cmd;
        }
    }
}
