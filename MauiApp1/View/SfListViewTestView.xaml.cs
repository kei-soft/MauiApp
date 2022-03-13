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
	/// 검색바
	/// </summary>
	SearchBar searchBar = null;

	/// <summary>
	/// 스크롤링을 제어할 VisualContainer
	/// </summary>
	//VisualContainer visualContainer;

	/// <summary>
	/// 알림여부
	/// </summary>
	//bool isAlertShown = false;

	/// <summary>
	/// 생성자
	/// </summary>
	public SfListViewTestView()
	{
		InitializeComponent();

		this.BindingContext = new SfListViewTestViewModel();

		// 목록 끝에 도달한 경우 알림 처리를 위함 - listview 아래 위로 공간이 많이 생기게 됨 버그같음
		//visualContainer = this.listView.GetVisualContainer();
		//visualContainer.ScrollRows.Changed += ScrollRows_Changed;

		// 아이템 정렬
		listView.DataSource.SortDescriptors.Add(new SortDescriptor { PropertyName = "BookName", Direction = ListSortDirection.Ascending });

		// 그룹핑
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
	/// 검색 텍스트 변경시 이벤트
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
	/// 검색 항목에 따른 필터 설정
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
	/// 스크롤링시 이벤트 - 목록 끝에 도달한 경우 알림처리를 위함 - listview 아래 위로 공간이 많이 생기게 됨 버그같음
	///</summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	//private void ScrollRows_Changed(object sender, ScrollChangedEventArgs e)
 //   {
 //       var lastIndex = this.visualContainer.ScrollRows.LastBodyVisibleLineIndex;

 //       //Header 사용 여부 +1
 //       var header = (this.listView.HeaderTemplate != null && !listView.IsStickyHeader) ? 1 : 0;

 //       //Footer 사용 여부 +1
 //       var footer = (this.listView.FooterTemplate != null && !this.listView.IsStickyFooter) ? 1 : 0;

	//	// 전체 항목에서 Header 와 Fotter 를 더하여 전체 수를 계산
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