using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;

namespace WpfApp3
{
	class ConnectionMySQL
	{
		//static string host = "85.11.116.137";
		//static string user = "admin";
		//static string pass = "Starkiler120.";
		static string host = "localhost";
		static string user = "root";
		static string pass = "";
		static string db = "uzytkownicy";
		static string dbProvider = "server=" + host + ";Database=" + db + ";User ID=" + user + ";Password=" + pass + ";";
		MySqlConnection mySql = new MySqlConnection(dbProvider);
		public void Connect()
		{
			try
			{
				mySql.Open();
			}
			catch (MySqlException er)
			{
				MessageBox.Show("Błąd połączenia! " + er.Message);
			}
		}
		public MySqlCommand Query(string x)
		{
			MySqlCommand command = new MySqlCommand(x,mySql);
			return command;
		}
		public void Disconnect()
		{
			mySql.Close();
		}
	}
}