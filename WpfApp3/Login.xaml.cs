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
	/// Logika interakcji dla klasy Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		QueryValidate validate = new QueryValidate();
		BoxValidate Box = new BoxValidate();
		public string nickname;
		public Login()
		{
			InitializeComponent();
		}
		private void submit_Click(object sender, RoutedEventArgs e)
		{
			nickname = nick.Text;
			string password = pass.Password;
			if (Box.Valid(nickname) && Box.Valid(password))
			{
				loginerrorr.Text = "";
				passerror.Text = "";
				if (validate.LoginValid(nickname, password) == 1)
				{
					this.Close();
				}
			}
			else if(!Box.Valid(nickname)&&!Box.Valid(password))
			{
				loginerrorr.Text = "Podaj login!";
				passerror.Text = "Podaj hasło!";
			}
			else if (Box.Valid(nickname)&&!Box.Valid(password))
			{
				loginerrorr.Text = "";
				passerror.Text = "Podaj hasło!";
			}
			else if (!Box.Valid(nickname) && Box.Valid(password))
			{
				loginerrorr.Text = "Podaj login!";
				passerror.Text = "";
			}
		}
		private void forgot_Click(object sender, RoutedEventArgs e)
		{
			Forgot forgot = new Forgot();
			forgot.Show();
			this.Close();
		}
	}
}