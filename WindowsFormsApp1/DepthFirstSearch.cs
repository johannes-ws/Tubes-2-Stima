using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearch
{
    class DepthFirstSearch
    {
        private List<Tuple<string, List<string>>> pairNode; //pasangan parent node dan child node, Tuple<parent, list<child>>;
        private Dictionary<string, string> pathToFile; // handles duplicate folder names
        private List<string> blue;
        private List<string> black;

        public DepthFirstSearch()
        {
            this.pairNode = new List<Tuple<string, List<string>>>();
            this.pathToFile = new Dictionary<string, string>();
            this.blue = new List<string>();
            this.black = new List<string>();
        }

        public string getNameDirectory(DirectoryInfo Folder)
        {
            string name = Folder.Name;
            if (!pathToFile.ContainsKey(name))
            {
                pathToFile.Add(name, Folder.FullName);
            }
            else if (pathToFile[name] != Folder.FullName)
            {
                int i = 0;
                while (pathToFile.ContainsKey(name + "(" + i + ")") && pathToFile[name + "(" + i + ")"] != Folder.FullName) i++;
                name = name + "(" + i + ")";
                if(!pathToFile.ContainsKey(name))pathToFile.Add(name, Folder.FullName);
            }
            return name;

        }

        public List<string> convertNameToList(DirectoryInfo[] Folders, FileInfo[] Files)
        {
            List<string> returnValue = new List<string>();

            foreach (DirectoryInfo folder in Folders)
            {

                returnValue.Add(getNameDirectory(folder));
            }

            foreach (FileInfo file in Files)
            {
                returnValue.Add(file.Name);
            }

            return returnValue;

        }

        public List<Tuple<string, List<string>>> getPairNode()
        {
            return this.pairNode;
        }
        public List<string> getBlue()
        {
            return this.blue;
        }

        public List<string> getBlack()
        {
            return this.black;
        }
        public string DFSoneFile(string root, string fileName)
        {
            DirectoryInfo directory = new DirectoryInfo(root);
            DirectoryInfo[] Folders = directory.GetDirectories();
            FileInfo[] Files = directory.GetFiles();
            string ret = "";
            string fileN = "File tidak ditemukan";

            List<string> nodeChild = this.convertNameToList(Folders, Files);
            string nameRoot = getNameDirectory(directory);


            Tuple<string, List<string>> parentChild = new Tuple<string, List<string>>(nameRoot, nodeChild);
            this.pairNode.Add(parentChild);
            foreach (FileInfo file in Files)
            {
                if (ret != "")
                {
                    black.Add(file.Name);
                }
                else if (file.Name == fileName)
                {
                    if(!blue.Contains(nameRoot))blue.Add(nameRoot);
                    blue.Add(file.Name);
                    ret = file.FullName;
                }
            }

            foreach (DirectoryInfo folder in Folders) 
            {
                if (fileN == "black")
                {
                    black.Add(getNameDirectory(folder));
                    continue;
                }
                if (ret != "")
                {
                    black.Add(getNameDirectory(folder));
                    continue;
                }
                fileN = DFSoneFile(folder.FullName, fileName);

                if (fileN != "File tidak ditemukan")
                {
                    if (!blue.Contains(nameRoot)) blue.Add(nameRoot);
                    blue.Add(getNameDirectory(folder));
                    ret = fileN;
                    fileN = "black";
                }
            }

            if (ret != "") return ret;


            return "File tidak ditemukan";
        }

        public void DFSmanyFile(string root, string filename, List<string> listPath) //listPath => semua path yang menuju filename
        {
            DirectoryInfo directory = new DirectoryInfo(root);
            DirectoryInfo[] Folders = directory.GetDirectories();
            FileInfo[] Files = directory.GetFiles();

            List<string> nodeChild = this.convertNameToList(Folders, Files);
            string nameRoot = getNameDirectory(directory);


            Tuple<string, List<string>> parentChild = new Tuple<string, List<string>>(nameRoot, nodeChild);
            this.pairNode.Add(parentChild);

            foreach (FileInfo file in Files)
            {
                if (file.Name == filename)
                {
                    blue.Add(nameRoot);
                    blue.Add(file.Name);
                    listPath.Add(file.FullName);
                }
            }

            foreach (DirectoryInfo folder in Folders)
            {
                int bef = listPath.Count;
                DFSmanyFile(folder.FullName, filename, listPath);
                if (bef < listPath.Count)
                {
                    blue.Add(nameRoot);
                    blue.Add(getNameDirectory(folder));
                }
            }
        }
    }
}
