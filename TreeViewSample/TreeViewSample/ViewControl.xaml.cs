using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreeViewSample.ViewModelObject;

namespace TreeViewSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainTreeView : TreeView
    {
        public MainTreeView()
        {
            InitializeComponent();

            #region Res Dictionary
            ResourceDictionary dict = new ResourceDictionary
            {
                Source = new Uri("TreeViewSample;component/Dictionary/TreeViewStyleDictionary.xaml", UriKind.Relative)
            };
            this.Resources.MergedDictionaries.Add(dict);
            ResourceDictionary dict2 = new ResourceDictionary
            {
                Source = new Uri("TreeViewSample;component/Dictionary/DataTemplateDictionary.xaml", UriKind.Relative)
            };
            this.Resources.MergedDictionaries.Add(dict2);
            #endregion

            ResolveDependencies();
        }

        internal void ResolveDependencies()
        {
            ViewModel = this.DataContext as ViewModel;
            this.ItemsSource = ViewModel.ViewItems;
        }

        public ViewModel ViewModel
        {
            get;
            set;
        }

        public virtual void OnGotFocus(object sender, RoutedEventArgs e)
        {
        }
    }

    public class ViewModel
    {
        private TimerAgent tagent = new TimerAgent();

        public ViewModel()
        {
            tagent.Elapsed += new EventHandler(OnTimerElapsed);

            var monitorItem = new MonitorItem("Elapsed counter", "0");
            var monitorItem2 = new MonitorItem("Elapsed counter2", "1000");

            var group = new MonitorItemsGroup("[ Initial ]");
            group.MonitorItems.Add(monitorItem);
            group.MonitorItems.Add(monitorItem2);

            var group2 = new MonitorItemsGroup("[ Initial2 ]");

            ViewItems.Add(group);
            ViewItems.Add(group2);
        }

        protected ObservableCollection<MonitorItemsGroup> viewItems = new ObservableCollection<MonitorItemsGroup>();

        public ObservableCollection<MonitorItemsGroup> ViewItems
        {
            get { return viewItems; }
        }

        public void OnTimerElapsed(object sender, EventArgs e)
        {
            foreach(var item in ViewItems)
            {
                var mon = item as MonitorItemsGroup;
                if(mon != null)
                {
                    foreach(var monitorItem in mon.MonitorItems)
                    {
                        monitorItem.Value = (int.Parse(monitorItem.Value) + 1).ToString();
                    }
                }
            }
        }
    }

    public class TimerAgent
    {
        public event EventHandler Elapsed;

        private System.Windows.Threading.DispatcherTimer dispatcherThread = new System.Windows.Threading.DispatcherTimer();

        public TimerAgent()
        {
            dispatcherThread.Interval = new System.TimeSpan(1000);
            dispatcherThread.Tick += new EventHandler(OnTimer);
            dispatcherThread.Start();
        }

        public void OnTimer(object sender, EventArgs e)
        {
            Elapsed(sender, e);
        }
    }

}
