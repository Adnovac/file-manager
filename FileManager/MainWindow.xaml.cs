using FileManager.Views;
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
using FileManager.DataElements;
using System.Windows.Shapes;

namespace FileManager
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            ElementsListView RightElementsList = new ElementsListView();
            ElementsListView LeftElementsList = new ElementsListView();
            Grid currentgrid;
            bool sizeOfDirectoryVisibility = true;
            public MainWindow()
            {
                InitializeComponent();
                RightElementsListGrid.Children.Add(RightElementsList);
                LeftElementsListGrid.Children.Add(LeftElementsList);
                UpdateTextBlocks(this);
                RightElementsList.UpdateEvent += UpdateTextBlocks;
                LeftElementsList.UpdateEvent += UpdateTextBlocks;
                RightElementsList.UpdateEvent += UpdateSelectedFileInfo;
                LeftElementsList.UpdateEvent += UpdateSelectedFileInfo;
                RightElementsList.OpenTextImageEvent += FileContentGridChange;
                LeftElementsList.OpenTextImageEvent += FileContentGridChange;
                ShowSizeOfDirectory();
            }

            public void UpdateTextBlocks(object e)
            {
                LeftListPath.Text = LeftElementsList.GetDirectory.Path;
                RightListPath.Text = RightElementsList.GetDirectory.Path;
            }



            public void UpdateSelectedFileInfo(object e)
            {
                if ((e as ElementsListView).ListBoxOfElements.SelectedItem != null)
                {
                    if ((e as ElementsListView).ListBoxOfElements.SelectedItem is FileView)
                        SelectedFileStatus.Text = ((e as ElementsListView).ListBoxOfElements.SelectedItem as FileView).GetFile.GetDescription();
                    else if ((e as ElementsListView).ListBoxOfElements.SelectedItem is DirectoryView && sizeOfDirectoryVisibility)
                        SelectedFileStatus.Text = ((e as ElementsListView).ListBoxOfElements.SelectedItem as DirectoryView).GetDirectory.GetDescription();
                    else if ((e as ElementsListView).ListBoxOfElements.SelectedItem is DirectoryView)
                        SelectedFileStatus.Text = ((e as ElementsListView).ListBoxOfElements.SelectedItem as DirectoryView).GetDirectory.GetDescriptionWithoutSize();

                }
            }
            public void FileContentGridChange(string tmp, bool isimage)
            {
                FileContentGrid.Children.Clear();
                FileContentText.Clear();
                if (isimage)
                    FileContentGrid.Children.Add(CreateImage(tmp));
                else
                    FileContentText.Text = tmp;
            }

            public Image CreateImage(string path)
            {
            Image image = new Image
            {
                Source = new BitmapImage(new Uri(path))
            };
            return image;
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (currentgrid == LeftElementsListGrid)
                {
                    LeftElementsList.DeleteFileDirectory();
                }
                else if (currentgrid == RightElementsListGrid)
                {
                    RightElementsList.DeleteFileDirectory();
                }
                LeftElementsList.ListDirectoriesAndFilesByName();
                RightElementsList.ListDirectoriesAndFilesByName();
            }


            private void LeftElementsListGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                currentgrid = LeftElementsListGrid;
            }

            private void RightElementsListGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                currentgrid = RightElementsListGrid;
            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                NewDirectoryWindow window;
                if (currentgrid == LeftElementsListGrid)
                {
                    window = new NewDirectoryWindow(LeftElementsList);
                    window.Show();
                }
                else if (currentgrid == RightElementsListGrid)
                {
                    window = new NewDirectoryWindow(RightElementsList);
                    window.Show();
                }
                LeftElementsList.ListDirectoriesAndFilesByName();
                RightElementsList.ListDirectoriesAndFilesByName();
            }

            public void InvokeEvents()
            {
                RightElementsList.InvokeUpdateEvent();
                LeftElementsList.InvokeUpdateEvent();
            }

            public void ShowSizeOfDirectory()
            {
                if (sizeOfDirectoryVisibility)
                {
                    sizeOfDirectoryVisibility = false;
                    SizeOfDirectoryVisibilityButton.Content = "Display directory size";
                }
                else
                {
                    sizeOfDirectoryVisibility = true;
                    SizeOfDirectoryVisibilityButton.Content = "Hide directory size";
                }
            }

            private void Button_Click_2(object sender, RoutedEventArgs e)
            {
                if (currentgrid == LeftElementsListGrid)
                {
                    LeftElementsList.CopyElement(RightElementsList.GetDirectory.Path);
                }
                else if (currentgrid == RightElementsListGrid)
                {
                    RightElementsList.CopyElement(LeftElementsList.GetDirectory.Path);
                }
                LeftElementsList.ListDirectoriesAndFilesByName();
                RightElementsList.ListDirectoriesAndFilesByName();
            }

            private void SizeOfDirectoryVisibilityButton_Click(object sender, RoutedEventArgs e)
            {
                ShowSizeOfDirectory();
            }
        }
    }