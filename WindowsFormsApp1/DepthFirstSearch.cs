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

        public DepthFirstSearch()
        {
            this.pairNode = new List<Tuple<string, List<string>>>();
            this.pathToFile = new Dictionary<string, string>();
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

        private string getNameRoot(string pathRoot)
        {
            string value = pathRoot;
            int len = pathRoot.Length - 1;

            bool found = false;
            while (len >= 0 && !found)
            {
                if (pathRoot[len] == '\\')
                {
                    found = true;
                }
                else
                {
                    len--;
                }
            }

            string discard = "";
            int j;
            for (j = 0; j <= len; j++)
            {
                discard += pathRoot[j];
            }

            pathRoot = pathRoot.Replace(discard, "");
            pathToFile.Add(pathRoot, value);
            return pathRoot;
        }

        public List<Tuple<string, List<string>>> getPairNode()
        {
            return this.pairNode;
        }

        public string DFSoneFile(string root, string name, string fileName, List<string> blue)
        {
            DirectoryInfo directory = new DirectoryInfo(root);
            DirectoryInfo[] Folders = directory.GetDirectories();
            FileInfo[] Files = directory.GetFiles();

            List<string> nodeChild = this.convertNameToList(Folders, Files);
            Tuple<string, List<string>> parentChild = new Tuple<string, List<string>>(name, nodeChild);

            this.pairNode.Add(parentChild);

            if (Folders.Length == 0)
            {
                foreach (FileInfo file in Files)
                {
                    if (file.Name == fileName)
                    {
                        blue.Add(file.Name);
                        return file.FullName;
                    }
                }
            }
            else
            {
                foreach (DirectoryInfo folder in Folders)
                {
                    string fileN = DFSoneFile(folder.FullName, getNameDirectory(folder), fileName, blue);

                    if (fileN != "File tidak ditemukan")
                    {
                        blue.Add(getNameDirectory(folder));
                        return fileN;
                    }
                }

                foreach (FileInfo file in Files) //File in root Directory
                {
                    if (file.Name == fileName)
                    {
                        blue.Add(file.Name);
                        return file.FullName;
                    }
                }

            }
            return "File tidak ditemukan";
        }


        public string DFSoneFile(string root, string fileName, List<string> blue)
        {
            DirectoryInfo directory = new DirectoryInfo(root);
            DirectoryInfo[] Folders = directory.GetDirectories();
            FileInfo[] Files = directory.GetFiles();

            List<string> nodeChild = this.convertNameToList(Folders, Files);
            string nameRoot = getNameRoot(root);


            Tuple<string, List<string>> parentChild = new Tuple<string, List<string>>(nameRoot, nodeChild);
            this.pairNode.Add(parentChild);

            if (Folders.Length == 0)
            {
                foreach (FileInfo file in Files)
                {
                    if (file.Name == fileName)
                    {
                        blue.Add(nameRoot);
                        blue.Add(file.Name);
                        return file.FullName;
                    }
                }
            }
            else
            {
                foreach (DirectoryInfo folder in Folders) //Terlebih dahulu memasuki Folder
                {
                    string fileN = DFSoneFile(folder.FullName, getNameDirectory(folder), fileName, blue);

                    if (fileN != "File tidak ditemukan")
                    {
                        blue.Add(nameRoot);
                        blue.Add(getNameDirectory(folder));
                        return fileN;
                    }
                }

                foreach (FileInfo file in Files) //File in root Directory
                {
                    if (file.Name == fileName)
                    {
                        blue.Add(nameRoot);
                        blue.Add(file.Name);
                        return file.FullName;
                    }
                }

            }
            return "File tidak ditemukan";
        }


        public void DFSmanyFile(string root, string name, string filename, List<string> listPath, List<string> blue)
        {
            DirectoryInfo directory = new DirectoryInfo(root);
            DirectoryInfo[] Folders = directory.GetDirectories();
            FileInfo[] Files = directory.GetFiles();

            List<string> nodeChild = this.convertNameToList(Folders, Files);
            Tuple<string, List<string>> parentChild = new Tuple<string, List<string>>(name, nodeChild);

            this.pairNode.Add(parentChild);

            if (Folders.Length == 0)
            {
                foreach (FileInfo file in Files)
                {
                    if (file.Name == filename)
                    {
                        blue.Add(file.Name);
                        listPath.Add(file.FullName);
                    }
                }
            }
            else
            {
                foreach (DirectoryInfo folder in Folders)
                {
                    int bef = listPath.Count;
                    DFSmanyFile(folder.FullName, getNameDirectory(folder), filename, listPath, blue);
                    if (listPath.Count > bef) blue.Add(getNameDirectory(folder));
                }

                foreach (FileInfo file in Files)
                {
                    if (file.Name == filename)
                    {
                        blue.Add(file.Name);
                        listPath.Add(file.FullName);
                    }
                }
            }
        }

        public void DFSmanyFile(string root, string filename, List<string> listPath, List<string> blue) //listPath => semua path yang menuju filename
        {
            DirectoryInfo directory = new DirectoryInfo(root);
            DirectoryInfo[] Folders = directory.GetDirectories();
            FileInfo[] Files = directory.GetFiles();

            List<string> nodeChild = this.convertNameToList(Folders, Files);
            string nameRoot = getNameRoot(root);


            Tuple<string, List<string>> parentChild = new Tuple<string, List<string>>(nameRoot, nodeChild);
            this.pairNode.Add(parentChild);

            if (Folders.Length == 0)
            {
                foreach (FileInfo file in Files)
                {
                    if (file.Name == filename)
                    {
                        blue.Add(nameRoot);
                        blue.Add(file.Name);
                        listPath.Add(file.FullName);
                    }
                }
            }
            else
            {
                foreach (DirectoryInfo folder in Folders)
                {
                    int bef = listPath.Count;
                    DFSmanyFile(folder.FullName, getNameDirectory(folder), filename, listPath, blue);
                    if (bef < listPath.Count)
                    {
                        blue.Add(nameRoot);
                        blue.Add(getNameDirectory(folder));
                    }
                }

                foreach (FileInfo file in Files)
                {
                    if (file.Name == filename)
                    {
                        blue.Add(nameRoot);
                        blue.Add(file.Name);
                        listPath.Add(file.FullName);
                    }
                }
            }
        }


    }
}
