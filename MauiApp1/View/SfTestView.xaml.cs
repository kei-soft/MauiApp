using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class SfTestView : ContentPage
{

	/// <summary>
	/// ������
	/// </summary>
	public SfTestView()
	{
		InitializeComponent();

		this.BindingContext = new SfTestViewModel();
	}
}