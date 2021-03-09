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

namespace WpfApp3
{
	/// <summary>
	/// Logika interakcji dla klasy Forgot.xaml
	/// </summary>
	public partial class Forgot : Window
	{
		QueryValidate validate = new QueryValidate();
		BoxValidate Box = new BoxValidate();
		public Forgot()
		{
			InitializeComponent();
		}
		private void submit_Click(object sender, RoutedEventArgs e)
		{
			string address=mail.Text;
			if (Box.Valid(address))
			{
				if (Box.MailValid(address))
				{
					if (validate.ForgotValid(address) == 1)
					{
						mail.Clear();
						mailerror.Text = "";
					}
					else
					{
						mail.Clear();
						mailerror.Text = "Spróbuj ponownie!";
					}
				}
				else
				{
					mailerror.Text = "Podaj prawidłowy adres e-mail!";
				}
			}
			else
			{
				mailerror.Text = "Podaj adres e-mail!";
			}
		}
		private void login_Click(object sender, RoutedEventArgs e)
		{
			Login login = new Login();
			login.Show();
			this.Close();
		}
	}
}