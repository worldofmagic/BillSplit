using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BillSplitting
{
    public class DataAnalysis
    {
        private string[] data;
        public DataAnalysis(string[] inputdata)
        {
            data = inputdata;
        }

        public int[] peopleNum()
        {
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
            return personNum;
        }

        public int[] peopleBillNum()
        {
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
            return personBillNum;
        }

        public string[] Data { get => data; set => data = value; }
    }
}
