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
    public class GetPersonBillTests
    {
        [TestMethod()]
        public void PersonBillTest()
        {
            string path = @"D:\resource\test.txt";
            ReadFile file = new ReadFile(path);
            string[] data = file.data();

            DataAnalysis dataanalysis = new DataAnalysis(data);
            int[] personBillNum = dataanalysis.peopleBillNum();
            int[] personNum = dataanalysis.peopleNum();

            int[] personIndex = GetPersonIndex.PersonIndex(data.Length, personBillNum);
            int[] groupIndex = GetGroupIndex.GroupIndex(data.Length, personNum);
            float[,] personBill = GetPersonBill.PersonBill(personIndex, groupIndex, data);

            decimal result = 30;

            Assert.AreEqual(result, (decimal)personBill[0,0]);
        }
    }
}