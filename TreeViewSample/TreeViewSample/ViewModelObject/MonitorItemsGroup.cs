using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewSample.ViewModelObject
{
    class MonitorItemsGroup : INotifyPropertyChanged, IDisposable
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

        public string GroupName
        {
            get;
            set;
        }

        public HashSet<MonitorItem> MonitorItems
        {
            get { return monitorItems; }
        }
    }
}
