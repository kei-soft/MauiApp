namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	/// <summary>
	/// 생성자
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void OnCounterClicked(object sender, EventArgs e)
	{
		this.count++;
		this.CounterLabel.Text = $"Current 수: {count}";
		
        SemanticScreenReader.Announce(this.CounterLabel.Text);
	}
}

