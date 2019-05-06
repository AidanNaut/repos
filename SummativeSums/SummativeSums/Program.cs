using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummativeSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray1 = new int[] { 1, 90, -33, -55, 67, -16, 28, -55, 15 };
            int[] intArray2 = new int[] { 999, -60, -77, 14, 160, 301 };
            int[] intArray3 = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, -99 };

            int sum1 = AddIntArray(intArray1);
            int sum2 = AddIntArray(intArray2);
            int sum3 = AddIntArray(intArray3);

            Console.WriteLine($"The Answer: {sum1}\nThe Most Elite: {sum2}\nThe Year After: {sum3}");
        }

        static int AddIntArray(int[] x)
        {
            int sum = 0;

            for (int i = 0; i < x.Length; i++)
            {
                sum += x[i];
            }
            return sum;
        }
    }
}
