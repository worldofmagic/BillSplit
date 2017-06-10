using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BillSplitting
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\resource\";
            Console.Write("Please Input File Name with extension: ");
            string filename = Console.ReadLine();

            string[] data = GetFileContent.GetDataFromFile(path+filename);

            int length = data.Length;
            int[] personNum = new int[length];
            int[] personBillNum = new int[length];
            int n = 0;
            while (n < length)
            {
                if (data[n] == "0")
                {
                    break;
                }
                else if (Regex.IsMatch(data[n], "^([0-9]{1,})$") && Regex.IsMatch(data[n + 1], "^([0-9]{1,})$"))
                {
                    personNum[n] = int.Parse(data[n]);
                    n++;
                    continue;
                }
                else if (Regex.IsMatch(data[n], "^([0-9]{1,})$") && Regex.IsMatch(data[n + 1], "^([0-9]{1,}[.][0-9]*)$"))
                {
                    personBillNum[n] = int.Parse(data[n]);
                    n++;
                    continue;
                }
                else
                {
                    n++;
                    continue;
                }
            }

            int[] personIndex = GetPersonIndex.PersonIndex(length, personBillNum);
            int[] groupIndex = GetGroupIndex.GroupIndex(length, personNum);
            float[,] personBill =GetPersonBill.PersonBill(personIndex, groupIndex,data);
            WriteResult.Write(data,personBill,personIndex,groupIndex,path,filename);
            Console.ReadKey();
        }      
    }
}
