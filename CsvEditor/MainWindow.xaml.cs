using CsvEditor.Const;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
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

namespace CsvEditor.Const
{
    static class MyResources
    {
        public static string menuTxtFile = "ファイル(F)";
        public static string menuTxtOpenNewFile = "新しいファイル";
        public static string menuTxtSaveFile = "名前を付けて保存";
        public static string menuTxtOverwriteFile = "上書き保存";
        public static string menuTxtSettings = "設定(C)";
    }
}

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

            if (!(bool)DesignerProperties.GetIsInDesignMode(this))
            {
                this.mnFile.Header = MyResources.menuTxtFile;
                this.mnNewFile.Header = MyResources.menuTxtOpenNewFile;
                this.mnSaveFile.Header = MyResources.menuTxtSaveFile;
                this.mnSettings.Header = MyResources.menuTxtSettings;
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