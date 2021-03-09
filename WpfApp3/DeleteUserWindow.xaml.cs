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
	/// Logika interakcji dla klasy DeleteUserWindow.xaml
	/// </summary>
	public partial class DeleteUserWindow : Window
	{
		ConnectionMySQL connection = new ConnectionMySQL();
		MySqlCommand command = new MySqlCommand();
		string login, name;
		public DeleteUserWindow(string a, string b)
		{
			InitializeComponent();
			login = b;
			name = a;
			string query = "SELECT rola FROM dane WHERE login='"+login+"'";
			connection.Connect();
			command = connection.Query(query);
			try
			{
				MySqlDataReader reader = command.ExecuteReader();
				reader.Read();
				if (Convert.ToString(reader.GetString("rola"))=="Administrator")
				{
					reader.Close();
					query = "SELECT login FROM dane";
					command = connection.Query(query);
					reader = command.ExecuteReader();
					while (reader.Read())
					{
						ComboBoxItem item = new ComboBoxItem();
						item.Content = Convert.ToString(reader.GetString("login"));
						UsersList.Items.Add(item);
					}
				}
				else
				{
					reader.Close();
					query = "SELECT login FROM dane WHERE rola!='Administrator' AND rola!='Dyrektor'";
					command = connection.Query(query);
					reader = command.ExecuteReader();
					while (reader.Read())
					{
						ComboBoxItem item = new ComboBoxItem();
						item.Content = Convert.ToString(reader.GetString("login"));
						UsersList.Items.Add(item);
					}
				}
			}
			catch (Exception er)
			{
				MessageBox.Show("Błąd: " + er);
			}
			UsersList.SelectedIndex = 0;
			connection.Disconnect();
		}

		private void back_Click(object sender, RoutedEventArgs e)
		{
			PanelWindow panel = new PanelWindow(name, login);
			panel.Show();
			this.Close();
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			string user = UsersList.SelectedItem.ToString();
			string[] vs = user.Split(":");
			user = vs[1].Trim();
			string query = "DELETE FROM pracownicy WHERE login='" + user + "';"+ "DELETE FROM dane WHERE login='" + user + "';";
			var result = MessageBox.Show("Na pewno chcesz usunąć użytkownika " + user + "?", "Potwierdzenie", MessageBoxButton.YesNo);
			if (result==MessageBoxResult.Yes)
			{
				connection.Connect();
				command = connection.Query(query);
				try
				{
					command.ExecuteNonQuery();
					MessageBox.Show("Pomyślnie usunięto użytkownika " + user);
					connection.Disconnect();
					DeleteUserWindow delete = new DeleteUserWindow(name, login);
					this.Close();
					delete.Show();
				}
				catch (Exception er)
				{
					MessageBox.Show("Błąd: "+er);
				}
			}
		}
	}
}
