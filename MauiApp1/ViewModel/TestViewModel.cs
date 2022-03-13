using System.ComponentModel;

namespace MauiApp1.ViewModel
{
    internal class TestViewModel : INotifyPropertyChanged
    {
        private string title = "Test Title";

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public TestViewModel()
        {
            //this.Title = "Test Title";
        }
    }
}
