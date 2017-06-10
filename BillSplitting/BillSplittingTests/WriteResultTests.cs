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
    public class WriteResultTests
    {
        [TestMethod()]
        public void WriteTest()
        {
            List<string> list = new List<string>();
            string line;
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"D:\resource\test.txt.out");
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
            
            string[] data1 = list.ToArray();


            Assert.AreEqual("($1.99)", data1[0]);
        }
    }
}