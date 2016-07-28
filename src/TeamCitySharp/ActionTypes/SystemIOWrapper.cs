using System.IO;

namespace TeamCitySharp.ActionTypes
{
    internal interface ISystemIOWrapper
    {
        string GetCurrentDirectory();
        bool DirectoryExists(string path);
        void CreateDirectory(string path);
        bool FileExists(string path);
        void DeleteFile(string path);
        void MoveFile(string srcFilename, string destFilename);
    }

    internal sealed class SystemIOWrapper : ISystemIOWrapper
    {
        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public void MoveFile(string srcFilename, string destFilename)
        {
            File.Move(srcFilename, destFilename);
        }
    }
}