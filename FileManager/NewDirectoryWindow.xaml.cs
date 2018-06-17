using FileManager.Views;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace FileManager
{
    /// <summary>
    /// Logika interakcji dla klasy NewDirectoryWindow.xaml
    /// </summary>
    public partial class NewDirectoryWindow : Window
    {
        ElementsListView elementlistview;
        string path;
        public NewDirectoryWindow(ElementsListView elementlistview)
        {
            InitializeComponent();
            this.elementlistview = elementlistview;
            path = elementlistview.GetDirectory.Path;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            path = path + "/" + NameOfNewDirectory.Text;
            Directory.CreateDirectory(path);
            elementlistview.ListDirectoriesAndFilesByName();
            Close();
        }
    }
}
