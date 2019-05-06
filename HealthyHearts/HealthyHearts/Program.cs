using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHearts
{
    class Program
    {
        public static int age;
        static void Main(string[] args)
        {
            double maxHR = 220;
            double HR;
            double lowHR;
            double highHR;

            Console.WriteLine("What is your age?");
            string strAge = Console.ReadLine();

            int.TryParse(strAge, out age);

            HR = maxHR - age;
            lowHR = HR * .5;
            highHR = HR * .85;

            Console.WriteLine($"Your maximum heartrate should be {HR} beats per minute.");
            Console.WriteLine($"Your target HR Zone is { Math.Round(lowHR)} - { Math.Round(highHR)} beats per minute.");

        }
    }
}
