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
	/// Logika interakcji dla klasy MenagerTaskWindow.xaml
	/// </summary>
	public partial class MenagerTaskWindow : Window
	{
		ConnectionMySQL connection = new ConnectionMySQL();
		MySqlCommand command = new MySqlCommand();
		string name, login;
		public MenagerTaskWindow(string a, string b)
		{
			InitializeComponent();
			name = a;
			login = b;
			string data = date.SelectedDate.Value.ToShortDateString();
			task.Text = "Zadania na " + data;
			string day = data.Substring(0, 2);
			string month = data.Substring(3, 2);
			string year = data.Substring(6, 4);
			data = year + "-" + month + "-" + day;
			string query = "SELECT rola FROM dane WHERE login='" + login + "';";
			connection.Connect();
			command = connection.Query(query);
			MySqlDataReader reader = command.ExecuteReader();
			reader.Read();
			if (Convert.ToString(reader.GetString("rola")) == "Kierownik")
			{
				connection.Disconnect();
				connection.Connect();
				query = "SELECT Nazwa FROM zadania,dane WHERE zadania.Data_wykonania='" + data + "' AND dane.rola=Pracownik";
				command = connection.Query(query);
				try
				{
					reader = command.ExecuteReader();
					while (reader.Read())
					{
						ComboBoxItem item = new ComboBoxItem();
						item.Content = Convert.ToString(reader.GetString("Nazwa"));
						tasks.Items.Add(item);
					}
				}
				catch (Exception er)
				{
					MessageBox.Show("Błąd: " + er.Message);
				}
				if (tasks.Items.Count == 0)
				{
					text.Text = "Brak zadań na dziś";
				}
				else
				{
					tasks.SelectedIndex = 0;
				}
			}
			else
			{
				query = "SELECT Nazwa FROM zadania WHERE Data_wykonania='" + data + "'";
				connection.Disconnect();
				connection.Connect();
				command = connection.Query(query);
				try
				{
					connection.Disconnect();
					connection.Connect();
					reader = command.ExecuteReader();
					while (reader.Read())
					{
						ListBoxItem item = new ListBoxItem();
						item.Content = Convert.ToString(reader.GetString("Nazwa"));
						tasks.Items.Add(item);
					}
				}
				catch (Exception er)
				{
					MessageBox.Show("Błąd: " + er);
				}
				if (tasks.Items.Count == 0)
				{
					text.Text = "Brak zadań na dziś";
				}
				else
				{
					tasks.SelectedIndex = 0;
				}
			}
			connection.Disconnect();
		}
		private void back_Click(object sender, RoutedEventArgs e)
		{
			PanelWindow panel = new PanelWindow(name, login);
			panel.Show();
			this.Close();
		}

		private void submit_Click(object sender, RoutedEventArgs e)
		{
			connection.Connect();
			if (tasks.SelectedItem != null)
			{
				string task_name = tasks.SelectedItem.ToString();
				string[] vs = task_name.Split(":");
				task_name = vs[1].Trim();
				string query = "SELECT zadania.Tresc, pracownicy.Imie, pracownicy.Nazwisko, zadania.Pracownik FROM zadania,dane,pracownicy WHERE Nazwa='" + task_name + "' AND pracownicy.Login=dane.login AND dane.login=zadania.Zlecajacy";
				command = connection.Query(query);
				try
				{
					MySqlDataReader reader = command.ExecuteReader();
					reader.Read();
					string a = reader.GetString("Tresc");
					string b,c;
					try
					{
						b = "Zlecił: " + reader.GetString("Imie") + " " + reader.GetString("Nazwisko");
						c = "Pracownik: " + reader.GetString("Pracownik");
					}
					catch (Exception)
					{
						b = "Zlecił: "+reader.GetString("Imie");
						c = "Pracownik: " + reader.GetString("Pracownik");
					}
					text.Text = a;
					menager.Text = b;
					employee.Text = c;
				}
				catch (Exception er)
				{
					MessageBox.Show("Błąd: " + er.Message);
				}
			}
			else
			{
				MessageBox.Show("Nie wybrano zadania z listy!");
			}
			connection.Disconnect();
		}

		private void datesubmit_Click(object sender, RoutedEventArgs e)
		{
			tasks.Items.Clear();
			string data = date.SelectedDate.Value.ToShortDateString();
			task.Text = "Zadania na " + data;
			text.Text = "";
			menager.Text = "";
			employee.Text = "";
			string day = data.Substring(0, 2);
			string month = data.Substring(3, 2);
			string year = data.Substring(6, 4);
			data = year + "-" + month + "-" + day;
			string query = "SELECT rola FROM dane WHERE login='" + login + "';";
			connection.Connect();
			command = connection.Query(query);
			MySqlDataReader reader = command.ExecuteReader();
			reader.Read();
			if (Convert.ToString(reader.GetString("rola")) == "Kierownik")
			{
				connection.Disconnect();
				connection.Connect();
				query = "SELECT Nazwa FROM zadania,dane WHERE zadania.Data_wykonania='" + data + "' AND dane.rola==Pracownik";
				command = connection.Query(query);
				reader = command.ExecuteReader();
				try
				{
					while (reader.Read())
					{
						ComboBoxItem item = new ComboBoxItem();
						item.Content = Convert.ToString(reader.GetString("Nazwa"));
						tasks.Items.Add(item);
					}
				}
				catch (Exception er)
				{
					MessageBox.Show("Błąd: " + er.Message);
				}
			}
			else
			{
				query = "SELECT Nazwa FROM zadania WHERE Data_wykonania='" + data + "'";
				connection.Disconnect();
				connection.Connect();
				command = connection.Query(query);
				try
				{
					connection.Disconnect();
					connection.Connect();
					reader = command.ExecuteReader();
					while (reader.Read())
					{
						ListBoxItem item = new ListBoxItem();
						item.Content = Convert.ToString(reader.GetString("Nazwa"));
						tasks.Items.Add(item);
					}
				}
				catch (Exception er)
				{
					MessageBox.Show("Błąd: " + er.Message);
				}
				if (tasks.Items.Count == 0)
				{
					text.Text = "Brak zadań na dziś";
				}
				else
				{
					tasks.SelectedIndex = 0;
				}
			}
			connection.Disconnect();
		}
	}
}