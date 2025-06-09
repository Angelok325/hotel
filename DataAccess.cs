using System;
using System.Data;
using System.Data.OleDb;

namespace Project_HMS
{
    public class DataAccess
    {
        private OleDbConnection oleCon;
        public OleDbConnection OleCon
        {
            get { return this.oleCon; }
            set { this.oleCon = value; }
        }

        private OleDbCommand oleCmd;
        public OleDbCommand OleCmd
        {
            get { return this.oleCmd; }
            set { this.oleCmd = value; }
        }

        private OleDbDataAdapter oleDa;
        public OleDbDataAdapter OleDa
        {
            get { return this.oleDa; }
            set { this.oleDa = value; }
        }

        private DataSet ds;
        public DataSet Ds
        {
            get { return this.ds; }
            set { this.ds = value; }
        }

        // Укажите правильный путь к вашей базе данных Access (.accdb)
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Users\User\Documents\Database411.accdb";

        public DataAccess()
        {
            this.OleCon = new OleDbConnection(connectionString);
            this.OleCon.Open();
        }

        private void QueryText(string query)
        {
            this.OleCmd = new OleDbCommand(query, this.OleCon);
        }

        public DataSet ExecuteQuery(string sql)
        {
            this.QueryText(sql);
            this.OleDa = new OleDbDataAdapter(this.OleCmd);
            this.Ds = new DataSet();
            this.OleDa.Fill(this.Ds);
            return this.Ds;
        }

        public DataTable ExecuteQueryTable(string sql)
        {
            this.QueryText(sql);
            this.OleDa = new OleDbDataAdapter(this.OleCmd);
            this.Ds = new DataSet();
            this.OleDa.Fill(this.Ds);
            return this.Ds.Tables[0];
        }

        public int ExecuteDML(string sql)
        {
            this.QueryText(sql);
            return this.OleCmd.ExecuteNonQuery();
        }

        // Не забудьте закрывать соединение при необходимости
        public void Close()
        {
            if (this.OleCon != null && this.OleCon.State == ConnectionState.Open)
            {
                this.OleCon.Close();
            }
        }
    }
}