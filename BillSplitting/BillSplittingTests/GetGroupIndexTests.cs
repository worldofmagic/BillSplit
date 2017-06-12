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
    public class GetGroupIndexTests
    {
        [TestMethod()]
        public void GroupIndexTest()
        {
            string path = @"D:\resource\test.txt";
            ReadFile file = new ReadFile(path);
            string[] data = file.data();

            DataAnalysis dataanalysis = new DataAnalysis(data);
            int[] personBillNum = dataanalysis.peopleBillNum();
            int[] personNum = dataanalysis.peopleNum();

                       
            int[] groupIndex = GetGroupIndex.GroupIndex(data.Length, personNum);

            Assert.AreEqual(13, groupIndex[1]);
        }
    }
}