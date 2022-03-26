using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class SfTestView : ContentPage
{

	/// <summary>
	/// »ý¼ºÀÚ
	/// </summary>
	public SfTestView()
	{
		InitializeComponent();

		this.BindingContext = new SfTestViewModel();
	}
}