using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TreeViewSample.ViewModelObject
{
    public class MonitorItemsGroup : INotifyPropertyChanged, IDisposable
    {
        protected readonly HashSet<MonitorItem> monitorItems = new HashSet<MonitorItem>();

        public event PropertyChangedEventHandler PropertyChanged;

        public MonitorItemsGroup(string name)
        {
            GroupName = name;
        }

        public void Dispose()
        {

        }

        private string groupName;
        public string GroupName
        {
            get { return groupName; }
            set
            {
                if (groupName == value) return;
                groupName = value;
                OnPropertyChanged("GroupName");
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

        public HashSet<MonitorItem> MonitorItems
        {
            get { return monitorItems; }
        }

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnSelected(object sender, RoutedEventArgs e)
        {
            IsSelected = true;
        }
    }
}
