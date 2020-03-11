using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Browser
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _entryUrl;
        public string EntryUrl {
            get => _entryUrl;
            set
            {
                _entryUrl = value;
                OnPropertyChanged();
            }
        }
        private string _webViewUrl;

        public Command ExecuteCommand { get; set; }

        public string WebViewUrl
        {
            get => _webViewUrl;
            set {
                EntryUrl = value;
                _webViewUrl = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            WebViewUrl = "https://www.google.com";
            ExecuteCommand = new Command(ChangeWebUrl);
        }

        private void ChangeWebUrl()
        {
            WebViewUrl = EntryUrl;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
