using System.ComponentModel;
using System.Windows.Input;

namespace MauiApp1.ViewModel;

internal class TestViewModel : INotifyPropertyChanged
{
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

    #region Command
    public ICommand TestCommand { get; private set; }
    public ICommand ParameterCommand { get; private set; }
    #endregion

    #region Field
    private string title = "MVVM Test";
    private string paramValue = "";
    #endregion

    #region Properties
    /// <summary>
    /// 타이틀
    /// </summary>
    public string Title
    {
        get { return this.title; }
        set
        {
            this.title = value;
            OnPropertyChanged("Title");
        }
    }

    /// <summary>
    /// 파라미터 값
    /// </summary>
    public string ParamValue
    {
        get { return this.paramValue; }
        set
        {
            this.paramValue = value;
            OnPropertyChanged("ParamValue");
        }
    }
    #endregion

    // Constructor
    #region  TestViewModel
    /// <summary>
    /// TestViewModel
    /// </summary>
    public TestViewModel()
    {
        this.TestCommand = new Command(OnTestCommand);
        this.ParameterCommand = new Command<string>(OnParameterCommand);
    }
    #endregion

    // Methods
    #region OnTestCommand
    private void OnTestCommand()
    {
        App.Current.MainPage.DisplayAlert("Test", "Test Command Click.", "OK");
    }
    #endregion

    #region OnParameterCommand(string param)
    private void OnParameterCommand(string param)
    {
        this.ParamValue = param;
    }
    #endregion
}

