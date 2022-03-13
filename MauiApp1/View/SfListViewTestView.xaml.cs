using MauiApp1.Model;
using MauiApp1.ViewModel;

using Syncfusion.Maui.DataSource;
using Syncfusion.Maui.GridCommon.ScrollAxis;
using Syncfusion.Maui.ListView;
using Syncfusion.Maui.ListView.Helpers;

namespace MauiApp1;

public partial class SfListViewTestView : ContentPage
{
	/// <summary>
	/// �˻���
	/// </summary>
	SearchBar searchBar = null;

	/// <summary>
	/// ��ũ�Ѹ��� ������ VisualContainer
	/// </summary>
	//VisualContainer visualContainer;

	/// <summary>
	/// �˸�����
	/// </summary>
	//bool isAlertShown = false;

	/// <summary>
	/// ������
	/// </summary>
	public SfListViewTestView()
	{
		InitializeComponent();

		this.BindingContext = new SfListViewTestViewModel();

		// ��� ���� ������ ��� �˸� ó���� ���� - listview �Ʒ� ���� ������ ���� ����� �� ���װ���
		//visualContainer = this.listView.GetVisualContainer();
		//visualContainer.ScrollRows.Changed += ScrollRows_Changed;

		// ������ ����
		listView.DataSource.SortDescriptors.Add(new SortDescriptor { PropertyName = "BookName", Direction = ListSortDirection.Ascending });

		// �׷���
		listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
		{
			PropertyName = "BookName",
			KeySelector = (object obj1) =>
			{
				var item = (obj1 as BookInfo);
				return item.BookName[0].ToString();
			}
		});
	}
	
	/// <summary>
	/// �˻� �ؽ�Ʈ ����� �̺�Ʈ
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
	{
		searchBar = (sender as SearchBar);
		if (listView.DataSource != null)
		{
			this.listView.DataSource.Filter = FilterContacts;
			this.listView.DataSource.RefreshFilter();
		}
	}

	/// <summary>
	/// �˻� �׸� ���� ���� ����
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
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

	///<summary>
	/// ��ũ�Ѹ��� �̺�Ʈ - ��� ���� ������ ��� �˸�ó���� ���� - listview �Ʒ� ���� ������ ���� ����� �� ���װ���
	///</summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	//private void ScrollRows_Changed(object sender, ScrollChangedEventArgs e)
 //   {
 //       var lastIndex = this.visualContainer.ScrollRows.LastBodyVisibleLineIndex;

 //       //Header ��� ���� +1
 //       var header = (this.listView.HeaderTemplate != null && !listView.IsStickyHeader) ? 1 : 0;

 //       //Footer ��� ���� +1
 //       var footer = (this.listView.FooterTemplate != null && !this.listView.IsStickyFooter) ? 1 : 0;

	//	// ��ü �׸񿡼� Header �� Fotter �� ���Ͽ� ��ü ���� ���
	//	var totalItems = this.listView.DataSource.DisplayItems.Count;// + header + footer;

 //       if ((lastIndex == totalItems - 1))
 //       {
 //           if (!this.isAlertShown)
 //           {
 //               DisplayAlert("Alert", "End of list reached...", "Ok");
 //               this.isAlertShown = true;
 //           }
 //       }
 //       else
 //       {
 //           this.isAlertShown = false;
 //       }
 //   }
}