using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillSplitting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BillSplitting.Tests
{
    [TestClass()]
    public class GetPersonIndexTests
    {
        [TestMethod()]
        public void PersonIndexTest()
        {

            string path = @"D:\resource\test.txt";
            string[] data = GetFileContent.GetDataFromFile(path);

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

            Assert.AreEqual(4, personIndex[1]);
        }
    }
}