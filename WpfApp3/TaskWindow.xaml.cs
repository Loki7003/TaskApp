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
	/// Logika interakcji dla klasy TaskWindow.xaml
	/// </summary>
	public partial class TaskWindow : Window
	{
		ConnectionMySQL connection = new ConnectionMySQL();
		MySqlCommand command = new MySqlCommand();
		string name, login;
		public TaskWindow(string a, string b)
		{
			InitializeComponent();
			string data = date.SelectedDate.Value.ToShortDateString();
			task.Text = "Zadania na " + data;
			string day = data.Substring(0, 2);
			string month = data.Substring(3, 2);
			string year = data.Substring(6, 4);
			data = year + "-" + month + "-" + day;
			string query = "SELECT Nazwa FROM zadania WHERE Data_wykonania='" + data + "' AND Pracownik='" + b + "'";
			connection.Connect();
			command = connection.Query(query);
			try
			{
				MySqlDataReader reader = command.ExecuteReader();
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
			connection.Disconnect();
			login = b;
			name = a;
		}
		private void datesubmit_Click(object sender, RoutedEventArgs e)
		{
			tasks.Items.Clear();
			string data = date.SelectedDate.Value.ToShortDateString();
			task.Text = "Zadania na " + data;
			text.Text = "";
			menager.Text = "";
			string day = data.Substring(0, 2);
			string month = data.Substring(3, 2);
			string year = data.Substring(6, 4);
			data = year + "-" + month + "-" + day;
			string query = "SELECT Nazwa, Zlecajacy FROM zadania WHERE Data_wykonania='" + data + "' AND Pracownik='"+login+"'";
			connection.Connect();
			command = connection.Query(query);
			try
			{
				MySqlDataReader reader = command.ExecuteReader();
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
			connection.Disconnect();
		}

		private void back_Click(object sender, RoutedEventArgs e)
		{
			HomeWindow home = new HomeWindow(name, login);
			home.Show();
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
				string query = "SELECT zadania.Tresc, pracownicy.Imie, pracownicy.Nazwisko FROM zadania,dane,pracownicy WHERE Nazwa='" + task_name + "' AND pracownicy.Login=dane.login AND dane.login=zadania.Zlecajacy";
				command = connection.Query(query);
				try
				{
					MySqlDataReader reader = command.ExecuteReader();
					//if (reader.HasRows) {
						reader.Read();
						string a = reader.GetString("Tresc");
						string b;
						try
						{
							b = "Zlecił: " + reader.GetString("Imie") + " " + reader.GetString("Nazwisko");
						}
						catch (Exception)
						{
							b = "Zlecił: " + reader.GetString("Imie");
						}
						text.Text = a;
						menager.Text = b;
					//}
				}
				catch (Exception er)
				{
					MessageBox.Show("Błąd: " + er.Message+"\n"+er.Source);
				}
			}
			else
			{
				MessageBox.Show("Nie wybrano zadania z listy!");
			}
			connection.Disconnect();
		}
	}
}