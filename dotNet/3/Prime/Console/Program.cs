using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest;
using System.Reflection.Metadata;

namespace Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始");

            
            var testClass = new Class1Tests();

            
            RunTest(() => testClass.PrimeFactors1(), "PrimeFactors1");
            RunTest(() => testClass.PrimeFactors2(), "PrimeFactors2");
            RunTest(() => testClass.PrimeFactors3(), "PrimeFactors3");
            RunTest(() => testClass.PrimeFactors4(), "PrimeFactors4");

            Console.WriteLine("结束");

            
            Console.ReadKey();

        }

        static void RunTest(Action testMethod, string testName)
        {
            try
            {
                testMethod();
                Console.WriteLine($"{testName}: 此案例通过");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{testName}: 此案例不通过 - {ex.Message}");
            }
        }
    }
}
