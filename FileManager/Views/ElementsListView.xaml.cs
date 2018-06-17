using FileManager.DataElements;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileManager.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ElementsListView.xaml
    /// </summary>
    public partial class ElementsListView : UserControl
    {
            public delegate void SomethingChanged(object e);
            public event SomethingChanged UpdateEvent;
            public delegate void OpenTextImage(string text, bool isimage);
            public event OpenTextImage OpenTextImageEvent;
            MyDirectory CurrentDirectory = new MyDirectory(AppDomain.CurrentDomain.BaseDirectory);
            List<MyElement> MyElements = new List<MyElement>();
            public ElementsListView()
            {
                InitializeComponent();
                ListDirectoriesAndFilesByDate();
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                    DiscComboBox.Items.Add(new DriveView(new MyDrive(drive.Name)));
            }

            public void ListDirectoriesAndFilesByName()
            {

                MyElements.Clear();
                MyElements.AddRange(CurrentDirectory.GetDirectories());
                MyElements.AddRange(CurrentDirectory.GetFiles());
                MyElements.Sort((x, y) => string.Compare(x.Name, y.Name));
                ViewList();
            }


            void ListDirectoriesAndFilesByDate()
            {
                MyElements.Clear();
                MyElements.AddRange(CurrentDirectory.GetDirectories());
                MyElements.AddRange(CurrentDirectory.GetFiles());
                MyElements.Sort((x, y) => string.Compare(x.GetCreationDate, y.GetCreationDate));
                ViewList();
            }


            void ListDirectoriesAndFilesByType()
            {
                MyElements.Clear();
                MyElements.AddRange(CurrentDirectory.GetFiles());
                MyElements.Sort((x, y) => string.Compare((x as MyFile).GetType, (y as MyFile).GetType));
                MyElements.AddRange(CurrentDirectory.GetDirectories());
                ViewList();
            }

            void ViewList()
            {
                ListBoxOfElements.Items.Clear();
                foreach (MyElement element in MyElements)
                {
                    if (element is MyFile)
                    {
                        ListBoxOfElements.Items.Add(new FileView(element as MyFile));
                    }
                    else if (element is MyDirectory)
                    {
                        ListBoxOfElements.Items.Add(new DirectoryView(element as MyDirectory));
                    }
                }
            }

            private void NamesButton_Click(object sender, RoutedEventArgs e)
            {
                ListDirectoriesAndFilesByName();
            }

            private void TypeButton_Click(object sender, RoutedEventArgs e)
            {
                ListDirectoriesAndFilesByType();
            }

            private void DateButton_Click(object sender, RoutedEventArgs e)
            {
                ListDirectoriesAndFilesByDate();
            }

            public MyDirectory GetDirectory
            {
                get
                {
                    return CurrentDirectory;
                }
            }

            public void InvokeUpdateEvent()
            {
                if (UpdateEvent != null)
                    UpdateEvent.Invoke(this);
            }

            void ItemDoubleClicked(object sender, MouseButtonEventArgs e)
            {
                if (ListBoxOfElements.SelectedItem is FileView)
                {
                    List<string> ImageExtensions = new List<string> { "JPG", "JPE", "BMP", "GIF", "PNG" };
                    MyFile file = (ListBoxOfElements.SelectedItem as FileView).GetFile;
                    string extension = file.GetType.ToUpper();
                    if (ImageExtensions.Contains(extension))
                    {
                        if (OpenTextImageEvent != null)
                            OpenTextImageEvent.Invoke(file.Path, true);
                    }
                    else if (extension == "TXT")
                    {
                        string text = File.ReadAllText(file.Path);
                        if (OpenTextImageEvent != null)
                            OpenTextImageEvent.Invoke(text, false);
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(file.Path);
                    }
                }
                else if (ListBoxOfElements.SelectedItem is DirectoryView)
                {
                    try
                    {
                        CurrentDirectory = (ListBoxOfElements.SelectedItem as DirectoryView).GetDirectory;
                        ListDirectoriesAndFilesByDate();
                        InvokeUpdateEvent();
                    }
                    catch
                    {
                        MessageBox.Show("Cannot open directory");
                    }
                }
            }

            void ItemMouseUp(object sender, MouseButtonEventArgs e)
            {
                if (UpdateEvent != null)
                    UpdateEvent.Invoke(this);
            }

            private void PreviousDirectoryButton_Click(object sender, RoutedEventArgs e)
            {
                string previouspath;
                previouspath = CurrentDirectory.Path.Substring(0, CurrentDirectory.Path.LastIndexOfAny(new char[] { '\\', '/' }));
                if (previouspath.Length < 3)
                    previouspath = previouspath + "\\";
                CurrentDirectory = new MyDirectory(previouspath);
                InvokeUpdateEvent();
                ListDirectoriesAndFilesByName();
            }

            public void DeleteFileDirectory()
            {
                if (ListBoxOfElements.SelectedItem is FileView)
                {
                    (ListBoxOfElements.SelectedItem as FileView).GetFile.Delete();
                }
                else if (ListBoxOfElements.SelectedItem is DirectoryView)
                {
                    (ListBoxOfElements.SelectedItem as DirectoryView).GetDirectory.Delete();
                }
            }

            public void CopyElement(string destpath)
            {
                if (ListBoxOfElements.SelectedItem is FileView)
                {
                    MyFile filetocopy = (ListBoxOfElements.SelectedItem as FileView).GetFile;
                    filetocopy.Copy(destpath);
                }

                else if (ListBoxOfElements.SelectedItem is DirectoryView)
                {
                    MyDirectory directorytocopy = (ListBoxOfElements.SelectedItem as DirectoryView).GetDirectory;
                    directorytocopy.Copy(destpath);
                }
            }

            private void DiscComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                try
                {
                    CurrentDirectory = new MyDirectory((DiscComboBox.SelectedItem as DriveView).GetDrive.Path);
                    ListDirectoriesAndFilesByDate();
                    InvokeUpdateEvent();
                }
                catch
                {
                    MessageBox.Show("Cannot open drive");
                }
            }

            private void FilterBar_TextChanged(object sender, TextChangedEventArgs e)
            {
                List<MyElement> MyElementsFiltered = new List<MyElement>();
                foreach (MyElement element in MyElements)
                {
                    if (element.Name.Contains(FilterBar.Text) || (element is MyFile && (element as MyFile).GetType.Contains(FilterBar.Text)))
                    {
                        MyElementsFiltered.Add(element);
                    }
                }
                ListBoxOfElements.Items.Clear();
                foreach (MyElement element in MyElementsFiltered)
                {
                    if (element is MyFile)
                        ListBoxOfElements.Items.Add(new FileView(element as MyFile));
                    else if (element is MyDirectory)
                        ListBoxOfElements.Items.Add(new DirectoryView(element as MyDirectory));
                }

            }
        
    }
}
