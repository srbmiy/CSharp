using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewSample.ViewModelObject
{
    public class MonitorItem : INotifyPropertyChanged, IDisposable
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

        private string variableString;
        public string Variable
        {
            get { return variableString ; }
            set
            {
                if (variableString == value) return;
                variableString = value;
                OnPropertyChanged("Variable");
            }
        }

        private string valueString;
        public string Value
        {
            get { return valueString; }
            set
            {
                if(valueString == value) return;
                valueString = value;
                OnPropertyChanged("Value");
            }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected == value) return;
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }


        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
