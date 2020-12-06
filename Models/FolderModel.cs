using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RWFM.Models
{
    public class FolderModel
    {
        private string absolutePath;
        private List<string> childFiles;
        private List<FolderModel> childFolders;
        private bool loaded = false;

        public FolderModel(string path)
        {
            absolutePath = path;
        }

        public List<FolderModel> GetChildFolders()
        {
            if (!IsLoaded())
            {
                LoadChildren();
            }
            return childFolders;
        }
        public List<string> GetChildFiles()
        {
            if (!IsLoaded())
            {
                LoadChildren();
            }
            return childFiles;
        }

        public bool IsLoaded()
        {
            return loaded;
        }

        public void LoadChildren()
        {
            if (Directory.Exists(absolutePath))
            {
                childFiles = Directory.GetFiles(absolutePath).ToList<string>();
                var directories = Directory.GetDirectories(absolutePath);
                childFolders = new List<FolderModel>();
                foreach (string directory in directories)
                {
                    childFolders.Add(new FolderModel(directory));
                }
                loaded = true;
            }
        }
    }
}
