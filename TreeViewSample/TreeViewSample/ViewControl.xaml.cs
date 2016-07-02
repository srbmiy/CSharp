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
            var item = new TreeViewItem();
            item.Header = "Added : ";
            var subitem = new TreeViewItem();
            subitem.Header = System.DateTime.Now.ToString();
            subitem.ToolTip = System.DateTime.Now.ToString();
            item.Items.Add(subitem);

            var item2 = new TreeViewItem();
            var monitorItem = new MonitorItem("D0", "999999");
            item2.Header = monitorItem;

            var item3 = new TreeViewItem();
            var group = new MonitorItemsGroup("[ Initial ]");
            group.MonitorItems.Add(monitorItem);
            item3.Header = group;

            ViewModel.ViewItems.Add(item);
            ViewModel.ViewItems.Add(item2);
            ViewModel.ViewItems.Add(item3);
        }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            var item = new TreeViewItem();
            item.Header = "aaaaaaaa";
            viewItems.Add(item);
        }

        protected ObservableCollection<TreeViewItem> viewItems = new ObservableCollection<TreeViewItem>();

        public ObservableCollection<TreeViewItem> ViewItems
        {
            get { return viewItems; }
        }
    }
}
