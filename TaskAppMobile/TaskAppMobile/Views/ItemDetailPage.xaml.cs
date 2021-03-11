using System.ComponentModel;
using TaskAppMobile.ViewModels;
using Xamarin.Forms;

namespace TaskAppMobile.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}