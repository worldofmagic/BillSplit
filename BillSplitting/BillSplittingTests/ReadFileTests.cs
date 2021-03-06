﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillSplitting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitting.Tests
{
    [TestClass()]
    public class ReadFileTests
    {
        [TestMethod()]
        public void dataTest()
        {
            string path = @"D:\resource\test.txt";
            ReadFile readfile = new ReadFile(path);
            string[] data1 = readfile.data();

            List<string> list = new List<string>();
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string line;
            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            file.Close();
            string[] data2 = list.ToArray();

            Assert.AreEqual(data1[0], data2[0]);
        }
    }
}