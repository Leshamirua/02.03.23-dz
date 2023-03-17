using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_system_homework_02._03._2023
{
    interface iFile
    {
        void InputData();
        void InputText();
        void CreateFile();
        void DeleteFile();
    }
    interface iPath
    {
        void CreatePath();
    }
    class File : iFile, iPath
    {
        private string Name;
        private string Description;
        private string Text;
        private const string _txt = ".txt";
        private string Path;

        public File() { }
        public File(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }
        public void InputData()
        {
            if (Name == null && Description == null)
            {
                Console.Write("Enter name: ");
                Name = Console.ReadLine();
                Console.Write("Enter description: ");
                Description = Console.ReadLine();
            }
            else Console.WriteLine("Data already in database");
        }
        public void InputText()
        {
            Console.Write("Enter text: ");
            Text = Console.ReadLine();
        }
        public void CreatePath()
        {
            Path = Name + _txt;
            Console.WriteLine("Path was created");
        }
        public void CreateFile()
        {
            FileStream File = new FileStream(Path, FileMode.Create);
            StreamWriter SW = new StreamWriter(File);
            Console.WriteLine("File was created");
            SW.WriteLine($"Name: {Name}");
            SW.WriteLine($"Description: {Description}");
            SW.WriteLine();
            SW.WriteLine(Text);
            Console.WriteLine("Data was added");
            SW.Close();
        }
        public void DeleteFile()
        {
            Console.Write("Enter path: ");
            string LocalPath = Console.ReadLine();
            FileInfo File = new FileInfo(LocalPath);
            if (File.Exists)
            {
                File.Delete();
                Console.WriteLine("File was deleted");
            }
            else Console.WriteLine("Error");
        }
    }
    class Program
    {
        static void Main()
        {
            File Obj = new File();
            Obj.InputData();
            Obj.InputText();
            Obj.CreatePath();
            Obj.CreateFile();
            Obj.DeleteFile();
        }
    }
}