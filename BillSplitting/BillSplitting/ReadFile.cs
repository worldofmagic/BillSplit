using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitting
{
    public class ReadFile
    {
        private string path;


        public ReadFile(string filepath)
        {
            path = filepath;
        }


        public string[] data() {
            string thispath = path;
            List<string> list = new List<string>();
            string line;
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(thispath);
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

        
        public string Path { get => path; set => path = value; }
    }
}
