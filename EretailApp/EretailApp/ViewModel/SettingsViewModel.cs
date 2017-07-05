using EretailApp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EretailApp.ViewModel
{
 public   class SettingsViewModel : ViewModelBase
    {
        public List<string> Languages { get; set; } = new List<string>()
        {
            "EN",
            "te",
            "ta",
             "hi"
        };

        private string _SelectedLanguage;

        public string SelectedLanguage
        {
            get { return _SelectedLanguage; }
            set
            {
                _SelectedLanguage = value;
                SetLanguage();
            }
        }

        public SettingsViewModel()
        {
            _SelectedLanguage = App.CurrentLanguage;
        }

        private void SetLanguage()
        {
            App.CurrentLanguage = SelectedLanguage;
            MessagingCenter.Send<object, CultureChangedMessage>(this,
                    string.Empty, new CultureChangedMessage(SelectedLanguage));
        }
    }
}
