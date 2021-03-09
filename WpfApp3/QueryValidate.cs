using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace WpfApp3
{
	class QueryValidate
	{
		ConnectionMySQL connection = new ConnectionMySQL();
		MySqlCommand command = new MySqlCommand();
		public int LoginValid(string a, string b)
		{
			connection.Connect();
			string query = "SELECT login,haslo FROM dane WHERE login='" +a+"' AND haslo='"+b+"';";
			command = connection.Query(query);
			int x=0;
			try
			{
				MySqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows) {
					reader.Read();
					string password = Convert.ToString(reader.GetString("haslo"));
					if (password == b)
					{
						connection.Disconnect();
						connection.Connect();
						command = connection.Query("SELECT imie FROM pracownicy WHERE login='" + a + "'");
						MySqlDataReader reader1 = command.ExecuteReader();
						reader1.Read();
						string name = Convert.ToString(reader1.GetString("imie"));
						query = "SELECT haslo FROM dane WHERE login='" + a + "';";
						connection.Disconnect();
						connection.Connect();
						command = connection.Query(query);
						reader = command.ExecuteReader();
						reader.Read();
						HomeWindow home = new HomeWindow(name, a);
						home.Show();
						if (Convert.ToString(reader.GetString("haslo")) == "zaq1@WSX")
						{
							PasswordChangeWindow passwordChange = new PasswordChangeWindow(name, a);
							passwordChange.Show();
							MessageBox.Show("Musisz zmienić hasło po pierwszym logowaniu!");
						}
						x++;
					}
				}
				else
				{
					MessageBox.Show("Podano błędny login lub hasło!");
				}
			}
			catch (Exception er)
			{
				MessageBox.Show("Błąd: " + er.Message);
			}
			connection.Disconnect();
			return x;
		}
		public int RegiserValid(string a, string b, string c, string d, string e)
		{
			connection.Connect();
			int x = 0;
			string query = "INSERT INTO dane (login, email, rola) VALUES ('"+a+"', '"+d+"','"+e+"');" +
				"INSERT INTO pracownicy VALUES ('"+b+"','"+c+"','"+a+"')";
			command = connection.Query(query);
			try
			{
				command.ExecuteNonQuery();
				x++;
			}
			catch (Exception er) 
			{
				MessageBox.Show("Błąd: " + er.Message);
			}
			connection.Disconnect();
			return x;
		}
		public int ForgotValid(string a)
		{
			connection.Connect();
			string query = "SELECT haslo FROM dane WHERE email='" + a + "'";
			command = connection.Query(query);
			int x = 0;
			try
			{
				MySqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					query = "UPDATE dane SET haslo=DEFAULT WHERE email='"+a+"'";
					reader.Close();
					command = connection.Query(query);
					command.ExecuteNonQuery();
					MessageBox.Show("Twoje hasło zostało zresetowane!");
					x++;
				}
				else
				{
					MessageBox.Show("Nie znaleniono podanego adresu e-mail!");
				}
			}
			catch (Exception er)
			{
				MessageBox.Show("Błąd: " + er.Message);
			};
			connection.Disconnect();
			return x;
		}
		public bool LoginUnique(string a)
		{
			connection.Connect();
			string query = "SELECT login FROM dane WHERE login='" + a + "'";
			command = connection.Query(query);
			try
			{
				MySqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					connection.Disconnect();
					return false;
				}
			}
			catch (Exception er)
			{
				MessageBox.Show("Błąd: " + er.Message);
			}
			connection.Disconnect();
			return true;
		}
		public bool MailUnique(string a)
		{
			connection.Connect();
			string query = "SELECT email FROM dane WHERE email='" + a + "'";
			command = connection.Query(query);
			try
			{
				MySqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					connection.Disconnect();
					return false;
				}
			}
			catch (Exception er)
			{
				MessageBox.Show("Błąd: " + er.Message);
			}
			connection.Disconnect();
			return true;
		}
		public bool PassIsGood(string a, string b)
		{
			string query = "SELECT * FROM dane WHERE haslo='" + a + "' AND login='" + b + "'";
			connection.Connect();
			command = connection.Query(query);
			MySqlDataReader reader = command.ExecuteReader();
			try
			{
				if (!reader.HasRows)
				{
					return false;
				}
			}
			catch (Exception er)
			{
				MessageBox.Show("Błąd: " + er.Message);
			}
			connection.Disconnect();
			return true;
		}
	}
}