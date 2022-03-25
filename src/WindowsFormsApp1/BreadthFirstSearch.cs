using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearch
{
    class BreadthFirstSearch
    {
        private List<Tuple<string, List<string>>> pairNode; //pasangan parent node dan child node, Tuple<parent, list<child>>;
        private Dictionary<string, string> pathToFile; // handles duplicate folder names
        private List<string> blue;
        private List<string> black;
        public BreadthFirstSearch()
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
                int i = 1;
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
        public string BFSoneFile(string root, string fileName)
        {
            DirectoryInfo directory = new DirectoryInfo(root);
            DirectoryInfo[] Folders;
            FileInfo[] Files;
            Dictionary<string, string> parent = new Dictionary<string, string>();
            string ret = "";

            List<string> nodeChild;
            string nameRoot = getNameDirectory(directory);
            Tuple<string, List<string>> parentChild;

            Queue<string> q = new Queue<string>();
            q.Enqueue(root);

            parent.Add(nameRoot, nameRoot);

            while (q.Count != 0)
            {
                string top = q.Dequeue();
                directory = new DirectoryInfo(top);
                Folders = directory.GetDirectories();
                Files = directory.GetFiles();
                nodeChild = this.convertNameToList(Folders, Files);
                parentChild = new Tuple<string, List<string>>(getNameDirectory(directory), nodeChild);
                this.pairNode.Add(parentChild);

                foreach (FileInfo file in Files)
                {
                    if (ret != "")
                    {
                        this.black.Add(file.Name);
                    }
                    else if (file.Name == fileName)
                    {
                        this.blue.Add(getNameDirectory(directory));
                        this.blue.Add(file.Name);
                        // get path
                        string p = getNameDirectory(directory);
                        while (parent[p] != p)
                        {
                            p = parent[p];
                            this.blue.Add(p);
                        }
                        ret = file.FullName;
                    }
                }

                foreach (DirectoryInfo folder in Folders)
                {
                    parent.Add(getNameDirectory(folder), getNameDirectory(directory));
                    q.Enqueue(folder.FullName);
                }

                if (ret != "")
                {
                    while (q.Count != 0)
                    {
                        top = q.Dequeue();
                        directory = new DirectoryInfo(top);
                        this.black.Add(getNameDirectory(directory));
                    }
                    return ret;
                }
            }

            return "File tidak ditemukan";
        }


        public void BFSmanyFile(string root,  string fileName, List<string> listPath)
        {
            DirectoryInfo directory = new DirectoryInfo(root);
            DirectoryInfo[] Folders;
            FileInfo[] Files;
            Dictionary<string, string> parent = new Dictionary<string, string>();

            List<string> nodeChild;
            string nameRoot = getNameDirectory(directory);
            Tuple<string, List<string>> parentChild;

            Queue<string> q = new Queue<string>();
            q.Enqueue(root);

            parent.Add(nameRoot, nameRoot);

            while (q.Count != 0)
            {
                string top = q.Dequeue();
                directory = new DirectoryInfo(top);
                Folders = directory.GetDirectories();
                Files = directory.GetFiles();
                nodeChild = this.convertNameToList(Folders, Files);
                parentChild = new Tuple<string, List<string>>(getNameDirectory(directory), nodeChild);
                this.pairNode.Add(parentChild);

                foreach (FileInfo file in Files)
                {
                  if (file.Name == fileName)
                    {
                        this.blue.Add(getNameDirectory(directory));
                        this.blue.Add(file.Name);
                        // get path
                        string p = getNameDirectory(directory);
                        while (parent[p] != p)
                        {
                            p = parent[p];
                            this.blue.Add(p);
                        }
                        listPath.Add(file.FullName);
                    }
                }

                foreach (DirectoryInfo folder in Folders)
                {
                    parent.Add(getNameDirectory(folder), getNameDirectory(directory));
                    q.Enqueue(folder.FullName);
                }
            }
        }
    }
}
