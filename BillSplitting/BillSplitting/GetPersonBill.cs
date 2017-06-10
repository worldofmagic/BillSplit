using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitting
{
    public class GetPersonBill
    {

        /// <summary>
        /// get the amout of each people paid
        /// </summary>
        /// <param name="personIndex">the index where value stands for people number and people's bills bigin</param>
        /// <param name="groupIndex">the index where trips begin</param>
        /// <param name="data">list of input file content</param>
        /// <returns>a 2D list PersonBill[i,j] which stands for the the total amout paid by the j th person of the i th trip  </returns>
        public static float[,] PersonBill(int[] personIndex, int[] groupIndex, string[] data)
        {
            float[,] personBill = new float[groupIndex.Length, personIndex.Length];
            for (int i = 0; i < groupIndex.Length; i++)
            {
                for (int j = 0; j < personIndex.Length; j++)
                {
                    int person = 0;
                    int billNum = 0;
                    if (i == groupIndex.Length - 1 && personIndex[j] > groupIndex[i] && personIndex[j] < data.Length)
                    {
                        person = personIndex[j];
                        billNum = int.Parse(data[person]);
                    }
                    else if (i < groupIndex.Length - 1 && personIndex[j] > groupIndex[i] && personIndex[j] < groupIndex[i + 1])
                    {
                        person = personIndex[j];
                        billNum = int.Parse(data[person]);
                    }
                    else
                    {
                        billNum = 0;
                    }

                    if (billNum == 0)
                    {
                        personBill[i, j] = 0;
                    }
                    else
                    {
                        for (int m = 0; m < billNum; m++)
                        {
                            int index = personIndex[j] + m + 1;
                            float bill = float.Parse(data[index]);
                            personBill[i, j] += bill;
                            // personBill[i, j] = double.Parse(data[index]);
                        }
                    }
                }
            }
            return personBill;
        }
    }
}
