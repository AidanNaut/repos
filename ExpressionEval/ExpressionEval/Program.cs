using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEval
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EvalNegative(5).ToString());
            Console.ReadKey();
        }

        static bool EvalNegative(int x)
        {
            return x < 0;
        }
    }
}
