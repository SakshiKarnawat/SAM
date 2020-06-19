using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DB
    {
        private static string connString = @"Data Source=C:\Users\Raak Laptop\Documents\RIT - Fall 2018\Software Modeling\SAM2019\SAM2019\SAM2019.db;Version=3;New=False;Compress=True;";

        public DataTable ExecuteQuery(string query)
        {
            SQLiteConnection conn = new SQLiteConnection(connString);
            SQLiteCommand cmd = conn.CreateCommand();
            string CommandText = query;
            SQLiteDataAdapter DB = new SQLiteDataAdapter(CommandText, conn);
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();

            conn.Open();
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            conn.Close();

            return DT;
        }

        public DataTable ExecuteQuery_Parametized(string query, List<object> parameters)
        {
            SQLiteConnection conn = new SQLiteConnection(connString);
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            SQLiteDataAdapter DB = new SQLiteDataAdapter(cmd);
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();


            foreach (object param in parameters)
            {
                cmd.Parameters.Add(new SQLiteParameter(DbType.Object, param));
            }

            conn.Open();
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            conn.Close();

            return DT;
        }

        public void ExecuteNonQuery(string query)
        {
            SQLiteConnection conn = new SQLiteConnection(connString);
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void ExecuteNonQuery_Parametized(string query, List<object> parameters)
        {
            SQLiteConnection conn = new SQLiteConnection(connString);
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;

            foreach(object param in parameters)
            {
                cmd.Parameters.Add(new SQLiteParameter(DbType.Object, param));
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int getStatus(string status)
        {
            SQLiteConnection conn = new SQLiteConnection(connString);
            SQLiteCommand cmd = conn.CreateCommand();

            string query = @"SELECT StatusID FROM Statuses WHERE Status LIKE '{0}'";
            query = String.Format(query, status);

            string CommandText = query;
            SQLiteDataAdapter DB = new SQLiteDataAdapter(CommandText, conn);
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();

            conn.Open();
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            conn.Close();

            return Int16.Parse(DT.Rows[0][0].ToString());
        }

        public int ExecuteNonQuery_Parametized_getKey(string query, List<object> parameters)
        {
            SQLiteConnection conn = new SQLiteConnection(connString);
            SQLiteCommand cmd = conn.CreateCommand();
            SQLiteCommand cmd_Key = conn.CreateCommand();

            cmd.CommandText = query;

            foreach (object param in parameters)
            {
                cmd.Parameters.Add(new SQLiteParameter(DbType.Object, param));
            }
           
            string query_Key = String.Format(@"SELECT last_insert_rowid()");
            cmd_Key.CommandText = query_Key;

            conn.Open();
            cmd.ExecuteNonQuery();
            object rowid = cmd_Key.ExecuteScalar();

            int result = int.Parse(rowid.ToString());

            conn.Close();

            return result;
        }
    }
}
