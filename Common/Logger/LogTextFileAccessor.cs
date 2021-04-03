using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logger
{
    public class LogTextFileAccessor : ILoggTextFileAccessor
    {
        private string FullDirectoryRoute => Directory.GetCurrentDirectory() + "/" + LoggFilesDirectoryName;
        private string LoggFilesDirectoryName => "LoggFiles";
        private string LoggFilePath => FullDirectoryRoute + "/loggs.txt";
        public LogTextFileAccessor()
        {
            EnsureExcelDirectoryExists();
            EnsureCreatedFile();
        }
        
        private void EnsureExcelDirectoryExists()
        {
            if (!Directory.Exists(FullDirectoryRoute))
            {
                Directory.CreateDirectory(FullDirectoryRoute);
            }
        }

        private void EnsureCreatedFile()
        {
            if (!File.Exists(LoggFilePath))
            {
                using (File.Create(LoggFilePath)) { } ;
            }
        }

        public void WriteNewLine(string text)
        {
            using (StreamWriter file = new StreamWriter(LoggFilePath, append: true)) {
                file.WriteLine($"{DateTime.Now:dd.MM.yyyy. HH:mm:ss.fff} - Logg : {text}");
            }
        }
    }

    public interface ILoggTextFileAccessor
    {
        void WriteNewLine(string text);
    }
}
