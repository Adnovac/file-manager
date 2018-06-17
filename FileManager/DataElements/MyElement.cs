using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataElements
{
    public abstract class MyElement
    {
        string path;
        public MyElement(string path)
        {
            this.path = path;

        }
        public abstract string GetCreationDate { get; }
        public abstract string Name { get; }
        abstract public void Delete();
        abstract public string GetSize();
        abstract public void Copy(string e);
        public string Path
        {
            get
            {
                return path;
            }
        }

        public string GetDescription()
        {
            return "Name: " + Name + "  Size: " + GetSize() + "B    Creation Date: " + GetCreationDate;
        }

    }
}
