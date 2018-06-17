using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataElements
{
    public class MyDrive
    {
        string path;
        public MyDrive(string path)
        {
            this.path = path;
        }

        public List<MyDirectory> GetDirectories()
        {
            string[] GettingDirectories = Directory.GetDirectories(path);
            List<MyDirectory> ListOfDirectories = new List<MyDirectory>();
            foreach (string directory in GettingDirectories)
            {
                ListOfDirectories.Add(new MyDirectory(directory));
            }
            return ListOfDirectories;
        }
        public List<MyFile> GetFiles()
        {
            string[] GettingFiles = Directory.GetFiles(path);
            List<MyFile> ListOfFiles = new List<MyFile>();
            foreach (string file in GettingFiles)
            {
                ListOfFiles.Add(new MyFile(file));
            }
            return ListOfFiles;
        }
        public string Path
        {
            get
            {
                return path;
            }
        }
    }
}
