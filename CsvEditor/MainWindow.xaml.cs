using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CsvEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            if ((bool)DesignerProperties.GetIsInDesignMode(this))
            {

            }
        }
        /// <summary>
        /// テスト用クリックイベント
        /// </summary>
        /// <param name="sender">イベント元</param>
        /// <param name="e">イベント引数</param>
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello world.");
        }
    }
}