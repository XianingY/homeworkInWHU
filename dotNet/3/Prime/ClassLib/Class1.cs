using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Class1
    {
        public static string PrimeFactors(int num)
        {

            if (num < 1 || num > 1000)
                throw new ArgumentOutOfRangeException(nameof(num), "请纠正输入为1到1000的正整数");

            List<int> factors = new List<int>();
            if (num <= 1) return num.ToString();

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                while (num % i == 0)
                {
                    factors.Add(i);
                    num /= i;
                }
            }

            if (num > 1)
            {
                factors.Add(num);
            }

            return string.Join("×", factors);
        }
    }
    
}
