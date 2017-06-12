using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillSplitting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitting.Tests
{
    [TestClass()]
    public class DataAnalysisTests
    {
        [TestMethod()]
        public void peopleNumTest()
        {
            string path = @"D:\resource\test.txt";
            ReadFile file = new ReadFile(path);
            string[] data = file.data();

            DataAnalysis dataanalysis = new DataAnalysis(data);
            int[] personNum = dataanalysis.peopleNum();
            Assert.AreEqual(personNum[0], 3);
        }

        [TestMethod()]
        public void peopleBillNumTest()
        {
            string path = @"D:\resource\test.txt";
            ReadFile file = new ReadFile(path);
            string[] data = file.data();

            DataAnalysis dataanalysis = new DataAnalysis(data);
            int[] peopleBillNum = dataanalysis.peopleBillNum();
            Assert.AreEqual(peopleBillNum[1], 2);
        }
    }
}