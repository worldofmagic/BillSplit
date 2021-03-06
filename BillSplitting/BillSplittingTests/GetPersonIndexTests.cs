﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            ReadFile file = new ReadFile(path);
            string[] data = file.data();

            DataAnalysis dataanalysis = new DataAnalysis(data);
            int[] personBillNum = dataanalysis.peopleBillNum();
            int[] personNum = dataanalysis.peopleNum();


            int[] personIndex = GetPersonIndex.PersonIndex(data.Length, personBillNum);

            Assert.AreEqual(4, personIndex[1]);
        }
    }
}