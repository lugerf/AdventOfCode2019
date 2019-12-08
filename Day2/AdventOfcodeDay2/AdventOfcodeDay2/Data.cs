using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfcodeDay2
{
    class Data
    {
        #region Definitions
        // Constants
        
        // Properties
        string Path { get; set; }
        string RawTextContent { get; set; }
        public List<Object> Results { get; set; } 

        // Class Variables
        #endregion

        /// <summary>
        /// Data reads data from OS harddrive and manipulates it's content. 
        /// Helping methods to return the data in necessary ways.
        /// </summary>
        /// <param name="path"></param>
        public Data(string path)
        {
            // Init
            Results = new List<object>();
            SetInputPath(path);
            ReadDataFromTextFile();
        }

        /// <summary>
        /// SetInputPath reads in path parameter, checks it for validity and sets class property if successful
        /// </summary>
        /// <param name="path"></param>
        private void SetInputPath(string path)
        {
            if (File.Exists(path))
            {
                Path = path;
            }
            else
            {
                throw new FileNotFoundException("File on specified input path does not exist");
            }
        }

        /// <summary>
        /// ReadDataFromTextFile reads data from a local text file into the class property File
        /// </summary>
        private void ReadDataFromTextFile()
        {
            if (File.Exists(Path))
            {
                RawTextContent = File.ReadAllText(Path);

                if (string.IsNullOrEmpty(RawTextContent))
                {
                    throw new Exception("File does not contain any data");
                }
            }
        }

        /// <summary>
        /// GetDataAsList returns the file content as a list of strings
        /// </summary>
        /// <returns></returns>
        public List<int> GetDataAsList()
        {
            List<int> result = new List<int>();

            string[] splitContent = RawTextContent.Split(',');
            
            foreach (string item in splitContent)
            {
                result.Add(int.Parse(item));
            }
            Results.Add(result);
            return result;
        }
    }
}
