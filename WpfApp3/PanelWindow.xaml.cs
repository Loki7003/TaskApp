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
	/// Logika interakcji dla klasy PanelWindow.xaml
	/// </summary>
	public partial class PanelWindow : Window
	{
		string name, login;
		public PanelWindow(string a, string b)
		{
			InitializeComponent();
			ConnectionMySQL connection = new ConnectionMySQL();
			MySqlCommand command = new MySqlCommand();
			string query = "SELECT rola FROM dane WHERE login='" + b + "';";
			connection.Connect();
			command = connection.Query(query);
			MySqlDataReader reader = command.ExecuteReader();
			reader.Read();
			if (Convert.ToString(reader.GetString("rola")) != "Administrator" && Convert.ToString(reader.GetString("rola")) != "Dyrektor")
			{
				AddUser.IsEnabled = false;
				DelUser.IsEnabled = false;
			}
			connection.Disconnect();
			login = b;
			name = a;
		}

		private void AddTask_Click(object sender, RoutedEventArgs e)
		{
			TaskCreator taskCreator = new TaskCreator(name, login);
			taskCreator.Show();
			this.Close();
		}

		private void SeeTasks_Click(object sender, RoutedEventArgs e)
		{
			MenagerTaskWindow menagerTask = new MenagerTaskWindow(name, login);
			menagerTask.Show();
			this.Close();
		}

		private void AddUser_Click(object sender, RoutedEventArgs e)
		{
			Register register = new Register(name, login);
			register.Show();
			this.Close();
		}

		private void back_Click(object sender, RoutedEventArgs e)
		{
			HomeWindow home = new HomeWindow(name,login);
			home.Show();
			this.Close();
		}

		private void DelUser_Click(object sender, RoutedEventArgs e)
		{
			DeleteUserWindow deleteUser = new DeleteUserWindow(name, login);
			deleteUser.Show();
			this.Close();
		}
	}
}
