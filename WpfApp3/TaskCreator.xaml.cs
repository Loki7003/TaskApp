using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfApp3
{
	/// <summary>
	/// Logika interakcji dla klasy TaskCreator.xaml
	/// </summary>
	public partial class TaskCreator : Window
	{
		string login, name;
		ConnectionMySQL connection = new ConnectionMySQL();
		MySqlCommand command = new MySqlCommand();
		public TaskCreator(string a, string b)
		{
			InitializeComponent();
			login = b;
			name = a;
			string query = "SELECT rola FROM dane WHERE login='" + login + "';";
			connection.Connect();
			command = connection.Query(query);
			MySqlDataReader reader = command.ExecuteReader();
			reader.Read();
			if (Convert.ToString(reader.GetString("rola")) == "Kierownik")
			{
				connection.Disconnect();
				connection.Connect();
				query = "SELECT login FROM dane WHERE rola='Pracownik'";
				command = connection.Query(query);
				reader = command.ExecuteReader();
				try
				{
					while (reader.Read())
					{
						ComboBoxItem item = new ComboBoxItem();
						item.Content = Convert.ToString(reader.GetString("login"));
						users.Items.Add(item);
					}
				}
				catch (Exception er)
				{
					MessageBox.Show("Błąd: " + er.Message);
				}
			}
			else
			{
				connection.Disconnect();
				connection.Connect();
				query = "SELECT login FROM dane";
				command = connection.Query(query);
				reader = command.ExecuteReader();
				try
				{
					while (reader.Read())
					{
						ComboBoxItem item = new ComboBoxItem();
						item.Content = Convert.ToString(reader.GetString("login"));
						users.Items.Add(item);
					}
				}
				catch (Exception er)
				{
					MessageBox.Show("Błąd: " + er.Message);
				}
			}
			connection.Disconnect();
			menager.Text = login;
		}

		private void back_Click(object sender, RoutedEventArgs e)
		{
			PanelWindow panel = new PanelWindow(name, login);
			panel.Show();
			this.Close();
		}

		private void submit_Click(object sender, RoutedEventArgs e)
		{
			if (taskName.Text != "")
			{
				if (taskContent.Text != "")
				{
					if (users.SelectedItem != null)
					{
						string data = date.SelectedDate.Value.ToShortDateString();
						string day = data.Substring(0, 2);
						string month = data.Substring(3, 2);
						string year = data.Substring(6, 4);
						data = year + "-" + month + "-" + day;
						string tname = taskName.Text;
						string tcontent = taskContent.Text;
						string employee = users.SelectedItem.ToString();
						string[] vs = employee.Split(":");
						employee = vs[1].Trim();
						string query = "INSERT INTO zadania (Nazwa, Tresc, Data_wykonania, Pracownik, Zlecajacy) VALUES ('" + tname + "','" + tcontent + "','" + data + "','" + employee + "','" + login + "')";
						connection.Connect();
						command = connection.Query(query);
						try
						{
							command.ExecuteNonQuery();
						}
						catch (Exception er)
						{
							MessageBox.Show("Błąd: " + er.Message);
						}
						connection.Disconnect();
					}
					else
					{
						MessageBox.Show("Wpisz treść zadania!");
					}
				}
				else
				{
					MessageBox.Show("Wpisz nazwę zadania!");
				}
			}
			else
			{
				MessageBox.Show("Wybierz pracownika!");
			}
		}
	}
}