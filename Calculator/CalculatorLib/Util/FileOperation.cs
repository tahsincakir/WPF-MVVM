using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib.Util
{
    public class FileOperation
    {
        public string ReadDataFromFile(string filePath)
        {
            string fileContent;

            try
            {
                fileContent = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("opps! something went wrong when loading settings! {0}", ex.Message));
            }

            return fileContent;
        }

        public void WriteDataToFile(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("opps! something went wrong when writing to file! {0}", ex.Message));
            }
        }
    }
}
