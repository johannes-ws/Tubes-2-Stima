using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DepthFirstSearch
    {
        private List<Tuple<string, List<string>>> pairNode; //pasangan parent node dan child node, Tuple<parent, list<child>>;

        public DepthFirstSearch()
        {
            this.pairNode = new List<Tuple<string, List<string>>>();
        }

        public List<string> convertNameToList(DirectoryInfo[] Folders, FileInfo[] Files)
        {
            List<string> returnValue = new List<string>();

            foreach (DirectoryInfo folder in Folders)
            {
                returnValue.Add(folder.Name);
            }

            foreach (FileInfo file in Files)
            {
                returnValue.Add(file.Name);
            }

            return returnValue;

        }

        private string getNameRoot(string pathRoot)
        {
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
            return pathRoot;
        }

        public List<Tuple<string, List<string>>> getPairNode()
        {
            return this.pairNode;
        }

        public string DFSoneFile(string root, string name, string fileName)
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
                        return file.FullName;
                    }
                }
            }
            else
            {
                foreach (DirectoryInfo folder in Folders)
                {
                    string fileN = DFSoneFile(folder.FullName, folder.Name, fileName);

                    if (fileN != "File tidak ditemukan")
                    {
                        return fileN;
                    }
                }

                foreach (FileInfo file in Files) //File in root Directory
                {
                    if (file.Name == fileName)
                    {
                        return file.FullName;
                    }
                }

            }
            return "File tidak ditemukan";
        }


        public string DFSoneFile(string root, string fileName)
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
                        return file.FullName;
                    }
                }
            }
            else
            {
                foreach (DirectoryInfo folder in Folders) //Terlebih dahulu memasuki Folder
                {
                    string fileN = DFSoneFile(folder.FullName, folder.Name, fileName);

                    if (fileN != "File tidak ditemukan")
                    {
                        return fileN;
                    }
                }

                foreach (FileInfo file in Files) //File in root Directory
                {
                    if (file.Name == fileName)
                    {
                        return file.FullName;
                    }
                }

            }
            return "File tidak ditemukan";
        }


        public void DFSmanyFile(string root, string name, string filename, List<string> listPath)
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
                        listPath.Add(file.FullName);
                    }
                }
            }
            else
            {
                foreach (DirectoryInfo folder in Folders)
                {
                    DFSmanyFile(folder.FullName, folder.Name, filename, listPath);
                }

                foreach (FileInfo file in Files)
                {
                    if (file.Name == filename)
                    {
                        listPath.Add(file.FullName);
                    }
                }
            }
        }

        public void DFSmanyFile(string root, string filename, List<string> listPath) //listPath => semua path yang menuju filename
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
                        listPath.Add(file.FullName);
                    }
                }
            }
            else
            {
                foreach (DirectoryInfo folder in Folders)
                {
                    DFSmanyFile(folder.FullName, folder.Name, filename, listPath);
                }

                foreach (FileInfo file in Files)
                {
                    if (file.Name == filename)
                    {
                        listPath.Add(file.FullName);
                    }
                }
            }
        }


    }
}
