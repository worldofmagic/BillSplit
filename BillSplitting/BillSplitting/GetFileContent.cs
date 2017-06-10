using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitting
{
    public class GetFileContent
    {

        /// <summary>
        /// get file content
        /// </summary>
        /// <param name="path">the path of input file</param>
        /// <returns>a string list of file content</returns>
        public static string[] GetDataFromFile(string path)
        {
            List<string> list = new List<string>();
            string line;
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    list.Add(line);
                }
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            return list.ToArray();
        }
    }
}
