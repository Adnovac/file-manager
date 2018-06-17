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
    /// Logika interakcji dla klasy DirectoryView.xaml
    /// </summary>
    public partial class DirectoryView : UserControl
    {
        MyDirectory CurrentDirectory;
        public DirectoryView(MyDirectory CurrentDirectory)
        {
            InitializeComponent();
            this.CurrentDirectory = CurrentDirectory;
            DirectoryDateText.Text = CurrentDirectory.GetCreationDate;
            DirectoryNameText.Text = CurrentDirectory.Name;

        }
        public MyDirectory GetDirectory
        {
            get
            {
                return CurrentDirectory;
            }
        }
    }
}
