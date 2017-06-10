using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitting
{
    public class GetGroupIndex
    {

        /// <summary>
        /// get the index of each person's bill number
        /// </summary>
        /// <param name="length">the total lines of input file</param>
        /// <param name="personNum">the number of people in each trip</param>
        /// <returns>a int list of index where new trip starts, and the value of this index stands for person number</returns>
        public static int[] GroupIndex(int length, int[] personNum)
        {
            List<int> list = new List<int>();
            for (int j = 0; j < length; j++)
            {
                if (personNum[j] != 0)
                {
                    list.Add(j);
                }
                continue;
            }

            return list.ToArray();
        }

    }
}
