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
    /// Logika interakcji dla klasy DriveView.xaml
    /// </summary>
    public partial class DriveView : UserControl
    {
        MyDrive drive;
        public DriveView(MyDrive drive)
        {
            InitializeComponent();
            this.drive = drive;
            DriveNameBlock.Text = drive.Path;
        }

        public MyDrive GetDrive
        {
            get
            {
                return drive;
            }
        }
    }
}
