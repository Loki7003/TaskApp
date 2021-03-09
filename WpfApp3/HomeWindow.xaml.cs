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
	/// Logika interakcji dla klasy HomeWindow.xaml
	/// </summary>
	public partial class HomeWindow : Window
	{
		ConnectionMySQL connection = new ConnectionMySQL();
		MySqlCommand command = new MySqlCommand();
		string name;
		string login;
		public HomeWindow(string a, string b)
		{
			InitializeComponent();
			Welcome.Text += a;
			name = a;
			login = b;
			ConnectionMySQL connection = new ConnectionMySQL();
			MySqlCommand command = new MySqlCommand();
			string query = "SELECT rola FROM dane WHERE login='"+login+"';";
			connection.Connect();
			command = connection.Query(query);
			MySqlDataReader reader = command.ExecuteReader();
			reader.Read();
			if (Convert.ToString(reader.GetString("rola")) == "Pracownik")
			{
				Panel.IsEnabled = false;
			}
			connection.Disconnect();
		}

		private void Tasks_Click(object sender, RoutedEventArgs e)
		{
			TaskWindow taskWindow = new TaskWindow(name,login);
			taskWindow.Show();
			this.Close();
		}

		private void Panel_Click(object sender, RoutedEventArgs e)
		{
			PanelWindow panelWindow = new PanelWindow(name, login);
			panelWindow.Show();
			this.Close();
		}

		private void Logout_Click(object sender, RoutedEventArgs e)
		{
			Login login = new Login();
			login.Show();
			this.Close();
		}

		private void ChangePassword_Click(object sender, RoutedEventArgs e)
		{
			PasswordChangeWindow window = new PasswordChangeWindow(name,login);
			window.Show();
		}
	}
}