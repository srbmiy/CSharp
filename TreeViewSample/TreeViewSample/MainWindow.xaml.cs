using System;
using System.Collections.Generic;
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

namespace TreeViewSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel ViewModel
        {
            get { return (ViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        private static readonly DependencyProperty ViewModelProperty
            = DependencyProperty.Register("ViewModel", typeof(ViewModel), typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();
        }

        internal MainWindow(MainTreeView viewModel) : this()
        {

        }

        protected virtual void OnGotFocus(object sender, RoutedEventArgs e)
        {
            TreeViewControl.OnGotFocus(sender, e);
        }
    }
}
