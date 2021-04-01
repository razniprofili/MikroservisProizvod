using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logger
{
    public class TextFileAccessor : ITextFileAccessor
    {
        private string LoggFilesDirectoryName => "LoggFiles";
        private string LoggFilePath => FullDirectoryRoute + "/loggs.txt";
        private string FullDirectoryRoute => Directory.GetCurrentDirectory() + "/" + LoggFilesDirectoryName;
        public TextFileAccessor()
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
                File.Create(LoggFilePath);
            }
        }

        public void WriteNewLine(string text)
        {
            var textFile = File.Open(LoggFilePath, FileMode.OpenOrCreate);
            //write new line.
        }

        public void UpdateExistingLine(string text)
        {
            // add code to end of line.
        }
    }

    public interface ITextFileAccessor
    {
        void WriteNewLine(string text);
        void UpdateExistingLine(string text);
    }
}
