using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewSample.ViewModelObject
{
    class MonitorItem : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MonitorItem(string variable, string value)
        {
            Variable = variable;
            Value = value;
        }

        public void Dispose()
        {

        }

        public string Variable
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }
}
