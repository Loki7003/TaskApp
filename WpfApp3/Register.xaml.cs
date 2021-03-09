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
	/// Logika interakcji dla klasy Register.xaml
	/// </summary>
	public partial class Register : Window
	{
		QueryValidate validate = new QueryValidate();
		BoxValidate Box = new BoxValidate();
		ConnectionMySQL connection = new ConnectionMySQL();
		MySqlCommand command = new MySqlCommand();
		string login, user_name;
		public Register(string a, string b)
		{
			InitializeComponent();
			login = b;
			user_name = a;
			string query = "SELECT * FROM role ORDER BY Nazwa DESC";
			connection.Connect();
			command = connection.Query(query);
			try
			{
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					ComboBoxItem item = new ComboBoxItem();
					item.Content = Convert.ToString(reader.GetString("Nazwa"));
					roles.Items.Add(item);
				}
				roles.SelectedIndex = 0;
			}
			catch (Exception er)
			{
				MessageBox.Show("Błąd: " + er.Message);
			}
			connection.Disconnect();
		}

		private void submit_Click(object sender, RoutedEventArgs e)
		{
			string nickname = nick.Text;
			string firstname = name.Text;
			string lastname = lname.Text;
			string address = mail.Text;
			string role = roles.SelectedItem.ToString();
			string[] vs = role.Split(":");
			role = vs[1].Trim();
			if (Box.Valid(nickname) && Box.Valid(firstname) && Box.Valid(lastname) && Box.Valid(address))
			{
				loginerror.Text = "";
				mailerror.Text = "";
				nameerror.Text = "";
				lnameerror.Text = "";
				if (validate.LoginUnique(nickname))
				{
					mailerror.Text = "";
					if (Box.MailValid(address))
					{
						loginerror.Text = "";
						if (validate.MailUnique(address))
							{
							mailerror.Text = "";
							if (validate.RegiserValid(nickname, firstname, lastname, address, role) == 1)
							{
								MessageBox.Show("Rejestracja zakończona powodzeniem!");
								nick.Clear();
								name.Clear();
								lname.Clear();
								mail.Clear();
							}
						}
						else
						{
							mailerror.Text = "Podany adres e-mail został użyty do rejestracji!";
						}
					}
					else
					{
						mailerror.Text = "Podaj prawidłowy adres e-mail!";
						
					}
				}
				else
				{
					loginerror.Text = "Ten login jest już zajęty!";
				}
			}
			else if (!Box.Valid(nickname) && !Box.Valid(firstname) && !Box.Valid(lastname) && !Box.Valid(address))
			{
				loginerror.Text = "Podaj login!";
				mailerror.Text = "Podaj adres e-mail!";
				nameerror.Text = "Podaj imię!";
				lnameerror.Text = "Podaj nazwisko!";
			}
			else if (Box.Valid(nickname) && !Box.Valid(firstname) && !Box.Valid(lastname) && !Box.Valid(address))
			{
				loginerror.Text = "";
				mailerror.Text = "Podaj adres e-mail!";
				nameerror.Text = "Podaj imię!";
				lnameerror.Text = "Podaj nazwisko!";
			}
			else if(!Box.Valid(nickname) && Box.Valid(firstname) && !Box.Valid(lastname) && !Box.Valid(address))
			{
				loginerror.Text = "Podaj login!";
				mailerror.Text = "Podaj adres e-mail!";
				nameerror.Text = "";
				lnameerror.Text = "Podaj nazwisko!";
			}
			else if(!Box.Valid(nickname) && !Box.Valid(firstname) && !Box.Valid(lastname) && Box.Valid(address))
			{
				loginerror.Text = "Podaj login!";
				mailerror.Text = "";
				nameerror.Text = "Podaj imię!";
				lnameerror.Text = "Podaj nazwisko!";
			}
			else if (!Box.Valid(nickname) && !Box.Valid(firstname) && Box.Valid(lastname) && !Box.Valid(address))
			{
				loginerror.Text = "Podaj login!";
				mailerror.Text = "Podaj adres e-mail!";
				nameerror.Text = "Podaj imię!";
				lnameerror.Text = "";
			}
			else if(Box.Valid(nickname) && Box.Valid(firstname) && !Box.Valid(lastname) && !Box.Valid(address))
			{
				loginerror.Text = "";
				mailerror.Text = "Podaj adres e-mail!";
				nameerror.Text = "";
				lnameerror.Text = "Podaj nazwisko!";
			}
			else if (Box.Valid(nickname) && !Box.Valid(firstname) && Box.Valid(lastname) && !Box.Valid(address))
			{
				loginerror.Text = "";
				mailerror.Text = "Podaj adres e-mail!";
				nameerror.Text = "Podaj imię!";
				lnameerror.Text = "";
			}
			else if (Box.Valid(nickname) && !Box.Valid(firstname) && !Box.Valid(lastname) && Box.Valid(address))
			{
				loginerror.Text = "";
				mailerror.Text = "";
				nameerror.Text = "Podaj imię!";
				lnameerror.Text = "Podaj nazwisko!";
			}
			else if (!Box.Valid(nickname) && Box.Valid(firstname) && Box.Valid(lastname) && !Box.Valid(address))
			{
				loginerror.Text = "Podaj login!";
				mailerror.Text = "Podaj adres e-mail!";
				nameerror.Text = "";
				lnameerror.Text = "";
			}
			else if (!Box.Valid(nickname) && Box.Valid(firstname) && !Box.Valid(lastname) && Box.Valid(address))
			{
				loginerror.Text = "Podaj login!";
				mailerror.Text = "";
				nameerror.Text = "";
				lnameerror.Text = "Podaj nazwisko!";
			}
			else if (!Box.Valid(nickname) && !Box.Valid(firstname) && Box.Valid(lastname) && Box.Valid(address))
			{
				loginerror.Text = "Podaj login!";
				mailerror.Text = "";
				nameerror.Text = "Podaj imię!";
				lnameerror.Text = "";
			}
			else if (Box.Valid(nickname) && Box.Valid(firstname) && Box.Valid(lastname) && !Box.Valid(address))
			{
				loginerror.Text = "";
				mailerror.Text = "Podaj adres e-mail!";
				nameerror.Text = "";
				lnameerror.Text = "";
			}
			else if (Box.Valid(nickname) && Box.Valid(firstname) && !Box.Valid(lastname) && Box.Valid(address))
			{
				loginerror.Text = "";
				mailerror.Text = "";
				nameerror.Text = "";
				lnameerror.Text = "Podaj nazwisko!";
			}
			else if (!Box.Valid(nickname) && Box.Valid(firstname) && Box.Valid(lastname) && Box.Valid(address))
			{
				loginerror.Text = "Podaj login!";
				mailerror.Text = "";
				nameerror.Text = "";
				lnameerror.Text = "";
			}
			else if (Box.Valid(nickname) && !Box.Valid(firstname) && Box.Valid(lastname) && Box.Valid(address))
			{
				loginerror.Text = "";
				mailerror.Text = "";
				nameerror.Text = "Podaj imię!";
				lnameerror.Text = "";
			}
		}
		private void back_Click(object sender, RoutedEventArgs e)
		{
			PanelWindow panel = new PanelWindow(user_name, login);
			panel.Show();
			this.Close();
		}
	}
}