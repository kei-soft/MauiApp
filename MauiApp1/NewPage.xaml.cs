namespace MauiApp1;

public partial class NewPage : ContentPage
{
	public NewPage()
	{
		InitializeComponent();

        if (Device.RuntimePlatform == Device.Android)
        {
            Padding = new Thickness(0, 10, 0, 0);
        }
        else if (Device.RuntimePlatform == Device.iOS)
        {
            Padding = new Thickness(0, 10, 0, 0);
        }
    }

    private void sfListViewButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new SfListViewTestView());
    }

    private void testButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TestView());
    }

    private void sfTestButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SfTestView());
    }
    
    private void sfTestButton_Clicked()
    {

    }
}