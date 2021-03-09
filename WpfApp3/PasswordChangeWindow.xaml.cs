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
	/// Logika interakcji dla klasy FirstLoginWindow.xaml
	/// </summary>
	public partial class PasswordChangeWindow : Window
	{
		string name, login;
		public PasswordChangeWindow(string a, string b)
		{
			InitializeComponent();
			name = a;
			login = b;
		}
		private void submit_Click(object sender, RoutedEventArgs e)
		{
			QueryValidate validate = new QueryValidate();
			BoxValidate box = new BoxValidate();
			ConnectionMySQL connection = new ConnectionMySQL();
			MySqlCommand command = new MySqlCommand();
			string oldPassword = oldPass.Password;
			string password = pass.Password;
			string rpassword = rpass.Password;
			if(validate.PassIsGood(oldPassword, login))
			{
				passerror.Text = "";
				if (box.PassValid(password))
				{
					if (box.SamePass(password, rpassword))
					{
						connection.Connect();
						string query = "UPDATE dane SET haslo='"+password+"' WHERE haslo='"+oldPassword+"'";
						command = connection.Query(query);
						try
						{
							command.ExecuteNonQuery();
							MessageBox.Show("Hasło zostało zmienione");
							this.Close();
						}
						catch(Exception er)
						{
							MessageBox.Show("Błąd: " + er.Message);
						}
						connection.Disconnect();
					}
					else
					{
						rpasserror.Text = "Hasła nie są takie same!";
					}
				}
				else
				{
					passerror.Text = "Hasło musi składać się z dużych i małych iter, znaku specjalnego, liczby oraz min. 8 znaków!";
				}
			}
			else
			{
				oldPasserror.Text = "Podano błędne hasło!";
			}
		}
	}
}