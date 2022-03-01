using MauiApp1.Model;
using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class SfListViewTestView : ContentPage
{
	SearchBar searchBar = null;

	public SfListViewTestView()
	{
		InitializeComponent();

		this.BindingContext = new SfListViewTestViewModel();
	}
	
	private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
	{
		searchBar = (sender as SearchBar);
		if (listView.DataSource != null)
		{
			this.listView.DataSource.Filter = FilterContacts;
			this.listView.DataSource.RefreshFilter();
		}
	}

	private bool FilterContacts(object obj)
	{
		if (searchBar == null || searchBar.Text == null)
			return true;

		var taskInfo = obj as BookInfo;
		if (taskInfo.BookName.ToLower().Contains(searchBar.Text.ToLower())
			|| taskInfo.BookDescription.ToLower().Contains(searchBar.Text.ToLower()))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}