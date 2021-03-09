using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WpfApp3
{
	class BoxValidate
	{
		public bool Valid(string a)
		{
			if (a=="")
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public bool MailValid(string a)
		{
			EmailAddressAttribute email = new EmailAddressAttribute();
			if (email.IsValid(a))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool PassValid(string a)
		{
			char[] vs = a.ToCharArray();
			int x = 0;
			foreach (char c in vs)
			{
				if (Char.IsDigit(c))
				{
					x++;
					break;
				}
			}
			foreach (char c in vs)
			{
				if (!Char.IsLetterOrDigit(c))
				{
					x++;
					break;
				}
			}
			if (a.Length < 8)
			{
				return false;
			}
			else if (a.ToUpper() == a || a.ToLower() == a)
			{
				return false;
			}
			else if (x!=2)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public bool SamePass(string a, string b)
		{
			if (a == b)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}