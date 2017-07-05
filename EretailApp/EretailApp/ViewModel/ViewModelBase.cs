using EretailApp.Localization;
using EretailApp.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EretailApp.ViewModel
{
   public class ViewModelBase : INotifyPropertyChanged
    {
        public LocalizedResources Resources
        {
            get;
            private set;
        }

        public ViewModelBase()
        {
            Resources = new LocalizedResources(typeof(LocalizationDemoResources), App.CurrentLanguage);
        }

        public void OnPropertyChanged([CallerMemberName]string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}