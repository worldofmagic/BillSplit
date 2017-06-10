using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitting
{
    public class WriteResult
    {

        /// <summary>
        /// write result into output file
        /// </summary>
        /// <param name="data">input file content</param>
        /// <param name="personBill">the total amout paid by each people in each trip</param>
        /// <param name="personIndex">the index of each people's bill number and where each people's bills begin</param>
        /// <param name="groupIndex">the index of each person's bill number and where trips begin</param>
        /// <param name="path">the directory of input file</param>
        /// <param name="filename">the file name of input file</param>
        public static void Write(string[] data, float[,] personBill, int[] personIndex, int[] groupIndex, string path, string filename)
        {
            string output = path + filename + ".out";
            try
            {
                if (File.Exists(output))
                {
                    File.Delete(output);
                }
                using (FileStream fs = File.Create(output)) ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            StreamWriter file = new StreamWriter(output);
            float[] groupTotal = new float[groupIndex.Length];
            decimal[] avg = new decimal[groupIndex.Length];
            for (int i = 0; i < groupIndex.Length; i++)
            {
                int personNum = int.Parse(data[groupIndex[i]]);
                for (int j = 0; j < personIndex.Length; j++)
                {
                    groupTotal[i] += personBill[i, j];
                }
                avg[i] =(decimal) groupTotal[i] / personNum;
            }


            for (int i = 0; i < groupIndex.Length; i++)
            {
                for (int j = 0; j < personIndex.Length; j++)
                {
                    decimal result;
                    if (i == groupIndex.Length - 1 && personIndex[j] > groupIndex[i] && personIndex[j] < data.Length)
                    {
                        if (avg[i] > (decimal)personBill[i, j])
                        {
                            result = Math.Round((avg[i] - (decimal)personBill[i, j]),2);
                            file.WriteLine("$" + result);
                        }
                        else
                        {
                            result = Math.Round(((decimal)personBill[i, j] - avg[i]),2);
                            file.WriteLine("($" + result + ")");
                        }
                    }
                    else if (i < groupIndex.Length - 1 && personIndex[j] > groupIndex[i] && personIndex[j] < groupIndex[i + 1])
                    {
                        if (avg[i] > (decimal)personBill[i, j])
                        {
                            result = Math.Round((decimal)(avg[i] - (decimal)personBill[i, j]), 2);
                            file.WriteLine("$" + result);
                        }
                        else
                        {
                            result = Math.Round((decimal)((decimal)personBill[i, j] - avg[i]), 2);
                            file.WriteLine("($" + result + ")");
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                file.WriteLine("");
            }


            file.Close();
            Console.WriteLine("Calculate Successfully, Please check the output file");
        }

    }
}
