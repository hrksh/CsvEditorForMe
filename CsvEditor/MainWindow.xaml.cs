using System.ComponentModel;
using System.Windows;
using GroupDocs.Editor;
using CsvEditor.Const;
using GroupDocs.Editor.Options;
using System.IO;

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

            // これ、.Net と .Net Frameworkで挙動が違うのかもしれないので調査する。
            if (DesignerProperties.GetIsInDesignMode(this))
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
            CSVManager.Inst().Init("hoge.csv");
            CSVManager.Inst().WordConvert("hoge", "Editid HOGE");
        }
    }

    // GroupDocs.Editor for .NET 利用で作成 (NuGet)
    // https://products.groupdocs.com/ja/editor/net/csv/

    public class CSVManager()
    {
        private static CSVManager _csMgr = null;

        public static CSVManager Inst()
        {
            if ( _csMgr == null) _csMgr = new CSVManager();
            return _csMgr;
        }

        Editor _editor = null;
        /// <summary>
        /// セパレータ
        /// </summary>
        DelimitedTextEditOptions _editOptions = null;
        DelimitedTextSaveOptions _saveOptions = null;

        EditableDocument _beforeEdit = null;
        EditableDocument _afterEdit = null;
        string content = string.Empty;


        public void Init(string filename) {

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
            if (!Path.Exists(path)) return;
            if (this._editor != null) return;

            // Editorインスタンス生成
            this._editor = new Editor(filename);
            this._editOptions = new DelimitedTextEditOptions(",");
            this._beforeEdit = this._editor.Edit(this._editOptions);
        }

        public void WordConvert(string beforeword, string afterword)
        {
            this.content = _beforeEdit.GetContent();
            string updatedContent = content.Replace(beforeword, afterword);
            this._afterEdit = EditableDocument.FromMarkup(updatedContent, null);
            this._saveOptions = new DelimitedTextSaveOptions(",");
            this._editor.Save(this._afterEdit, "edited.csv", this._saveOptions);
        }
    }
}