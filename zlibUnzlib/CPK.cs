using CriCpkMaker;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MustafaUğuz.PES2017.Common
{
    public class CRIArchiveFile
    {
        public string Path { get; set; }

        public string CpkPath { get; set; }

        public uint ID = 0;
    }

    public class CPK
    {
        public uint DataAlign = 2048;
        //public string BaseDirectory = Application.StartupPath;
        public CpkMaker.EnumCpkFileMode FileMode = CpkMaker.EnumCpkFileMode.ModeFilename;
        public bool Mask = true;
        public bool TryCompression = false;

        public string WorkingMessage = "";
        public string ErrorMessage = "";
        public Status Status;
        public double Progress;

        public string FilePath = "";

        public CpkMaker cpkMaker = new CpkMaker(false);
        
        public List<CRIArchiveFile> GetFilesFromFolder(string folderPath, string searchPattern = "*", SearchOption searchOption = SearchOption.AllDirectories)
        {
            var files = new List<CRIArchiveFile>(0);
            foreach (var file in new DirectoryInfo(folderPath).GetFiles(searchPattern, searchOption))
                files.Add(new CRIArchiveFile()
                {
                    Path = file.FullName,
                    CpkPath = GetCPKPath(folderPath, file.FullName)
                });
            return files;
        }

        public string GetCPKPath(string folderPath, string filePath)
        {
            return filePath.Substring(folderPath.Length + 1);
        }

        public CPK(string filePath)
        {
            FilePath = filePath;
            if (File.Exists(FilePath))
                cpkMaker.AnalyzeCpkFile(FilePath);
        }

        public void Build(IEnumerable<CRIArchiveFile> files)
        {
            foreach (var progress in IBuild(files));
        }

        public IEnumerable<double> IBuild(IEnumerable<CRIArchiveFile> files)
        {
            yield return 0;
            cpkMaker.DataAlign = DataAlign;
            cpkMaker.CpkFileMode = FileMode;
            cpkMaker.ToolVersion = "CPKMG1.36.00";
            cpkMaker.Mask = Mask;
            //cpkMaker.BaseDirectory = BaseDirectory;

            uint id = 1;

            cpkMaker.ClearFile();
            foreach (var file in files)
            {
                cpkMaker.AddFile(file.Path, file.CpkPath, file.ID, false);
                id++;
            }

            cpkMaker.EnableEtoc = true;
            cpkMaker.ForceCompress = TryCompression;
            
            cpkMaker.StartToBuild(FilePath + ".cpk");

            while (cpkMaker.GetProgress() < 100)
            {
                Status = cpkMaker.Execute();
                double progress = Progress = cpkMaker.GetProgress();
                WorkingMessage = cpkMaker.WorkingMessage;
                ErrorMessage = cpkMaker.ErrorMessage;
                yield return progress;
            }

            cpkMaker.Dispose();
            yield return 100;
        }

        public void Extract(string outputFolder)
        {
            foreach (var progress in IExtract(outputFolder));
        }

        public IEnumerable<double> IExtract(string outputFolder)
        {
            yield return 0;
            cpkMaker.AnalyzeCpkFile(FilePath);
            cpkMaker.StartToExtract(outputFolder);

            while (cpkMaker.GetProgress() < 100)
            {
                Status = cpkMaker.Execute();
                double progress;
                Progress = progress = cpkMaker.GetProgress();
                yield return progress;
            }

            yield return 100;
        }
        
        //public List<CFileInfo> AllFileInfos => cpkMaker.FileData.FileInfos;

        //public string[] AllFilePaths => cpkMaker.FileData.FileInfos.Select(p => p.ContentFilePath).ToArray();

        public byte[] GetFile(string filePathInCpk)
        {
            byte[] result = new byte[0];
            
            var fileInfo = cpkMaker.FileData.FileInfos.Where(p => p.ContentFilePath == filePathInCpk).OrderBy(p => p.RegisteredId).ToArray()[0];

            using (Stream stream = File.OpenRead(FilePath))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                reader.BaseStream.Position = (long)fileInfo.Offset;
                result = reader.ReadBytes((int)fileInfo.Filesize);
            }

            return result;
        }
    }
}
