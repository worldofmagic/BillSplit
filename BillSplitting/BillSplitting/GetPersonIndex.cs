using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitting
{
    public class GetPersonIndex
    {

        /// <summary>
        /// get the index of each people's bill number and where each people's bills begin
        /// </summary>
        /// <param name="length">the total lines of input file content</param>
        /// <param name="personBillNum">each people's bill number</param>
        /// <returns>a int list of index of each people's bill number and where each people's bills begin </returns>
        public static int[] PersonIndex(int length, int[] personBillNum)
        {
            List<int> list = new List<int>();

            for (int k = 0; k < length; k++)
            {
                if (personBillNum[k] != 0)
                {
                    list.Add(k);
                }
                continue;

            }

            return list.ToArray();
        }
    }
}
