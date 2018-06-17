using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataElements
{
    public class MyDirectory : MyElement
    {
        DateTime CreationTime;
        string name;
        public MyDirectory(string path) : base(path)
        {
            CreationTime = Directory.GetCreationTime(path + "/");
            name = path.Substring(path.LastIndexOfAny(new char[] { '\\', '/' }) + 1);
        }

        /// <summary>
        /// Returns list of MyFile objects in directory
        /// </summary>
        /// <returns></returns>
        public List<MyFile> GetFiles()
        {
            string[] GettingFiles = Directory.GetFiles(Path);
            List<MyFile> ListOfFiles = new List<MyFile>();
            foreach (string file in GettingFiles)
            {
                ListOfFiles.Add(new MyFile(file));
            }
            return ListOfFiles;
        }

        /// <summary>
        /// Returns list of MyDirectory objects in directory
        /// </summary>
        /// <returns></returns>
        public List<MyDirectory> GetDirectories()
        {

            string[] GettingDirectories = Directory.GetDirectories(Path);
            List<MyDirectory> ListOfDirectories = new List<MyDirectory>();
            foreach (string directory in GettingDirectories)
            {
                ListOfDirectories.Add(new MyDirectory(directory));
            }
            return ListOfDirectories;
        }

        public override void Delete()
        {
            string[] files = Directory.GetFiles(Path);
            string[] directories = Directory.GetDirectories(Path);
            foreach (string file in files)
            {
                (new MyFile(file)).Delete();
            }
            foreach (string directory in directories)
            {
                (new MyDirectory(directory)).Delete();
            }
            Directory.Delete(Path);
        }

        public override string GetSize()
        {
            try
            {
                return Directory.GetFiles(Path, "*", SearchOption.AllDirectories).Sum(t => (new FileInfo(t).Length)).ToString();
            }
            catch
            {
                return "There was a problem with getting path";
            }
        }

        public override string GetCreationDate
        {
            get
            {
                return CreationTime.ToShortDateString();
            }
        }

        public override string Name
        {
            get
            {
                return name;
            }
        }

        public override void Copy(string path)
        {
            try
            {
                string[] files = Directory.GetFiles(Path);
                string[] directories = Directory.GetDirectories(Path);
                Directory.CreateDirectory(path + "/" + Name);
                foreach (string file in files)
                {
                    (new MyFile(file)).Copy(path + "/" + Name);
                }
                foreach (string directory in directories)
                {
                    (new MyDirectory(directory)).Copy(path + "/" + Name);
                }
            }
            catch { }
        }

        public string GetDescriptionWithoutSize()
        {
            return "Name: " + Name + "   Creation Date: " + GetCreationDate;
        }
    }
}
