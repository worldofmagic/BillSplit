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

            ReadFile file = new ReadFile(path + filename);
            string[] data = file.data();

            DataAnalysis dataanalysis = new DataAnalysis(data);
            int[] personBillNum = dataanalysis.peopleBillNum();
            int[] personNum = dataanalysis.peopleNum();
            //foreach (int i in personBillNum)
            //{
            //    Console.WriteLine(i);
            //}
            //foreach (int i in personNum)
            //{
            //    Console.WriteLine(i);
            //}


            int[] personIndex = GetPersonIndex.PersonIndex(data.Length, personBillNum);
            int[] groupIndex = GetGroupIndex.GroupIndex(data.Length, personNum);
            float[,] personBill =GetPersonBill.PersonBill(personIndex, groupIndex,data);
            WriteResult.Write(data,personBill,personIndex,groupIndex,path,filename);
            Console.ReadKey();
        }      
    }
}
