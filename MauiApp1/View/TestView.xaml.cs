using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class TestView : ContentPage
{
	public TestView()
	{
		InitializeComponent();

		this.BindingContext = new TestViewModel();
	}
}