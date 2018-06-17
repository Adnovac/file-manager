using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileManager.DataElements
{
    public class MyFile : MyElement
    {
        string name;
        string type;
        DateTime CreationTime;
        public MyFile(string path) : base(path)
        {
            CreationTime = File.GetCreationTime(path + "/");
            name = path.Substring(path.LastIndexOfAny(new char[] { '\\', '/' }) + 1);
            try
            {
                name = name.Substring(0, name.LastIndexOf('.'));
            }
            catch
            {
                name = "unknown";
            }
            type = path.Substring(path.LastIndexOf('.') + 1);
        }


        public override void Delete()
        {
            try
            {
                File.Delete(Path);
            }
            catch
            {
                MessageBox.Show("Cannot delete file");
            }
        }

        public override void Copy(string path)
        {
            path = path + "/" + Name + "." + GetType;
            try
            {
                File.Copy(Path, path);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public override string GetSize()
        {
            return new FileInfo(Path).Length.ToString();
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

        new public string GetType
        {
            get
            {
                return type;
            }
        }

    }
}
