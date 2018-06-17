using FileManager.DataElements;
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

namespace FileManager.Views
{
    /// <summary>
    /// Logika interakcji dla klasy FileView.xaml
    /// </summary>
    public partial class FileView : UserControl
    {
        MyFile CurrentFile;
        public FileView(MyFile CurrentFile)
        {
            InitializeComponent();
            this.CurrentFile = CurrentFile;
            FileNameText.Text = CurrentFile.Name;
            FileTypeText.Text = CurrentFile.GetType;
            FileDateText.Text = CurrentFile.GetCreationDate;
        }

        public MyFile GetFile
        {
            get
            {
                return CurrentFile;
            }
        }
    }
}
