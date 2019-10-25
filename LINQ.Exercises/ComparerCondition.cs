using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Exercises
{
    public class ComparerCondition : IComparer <string>
    {
        public int Compare(string x, string y)
        {
            int calculated_length_x = CalculatedLength(x);
            int calculated_length_y = CalculatedLength(y);

            if (calculated_length_x > calculated_length_y)
            {
                return 1;
            }
            else if (calculated_length_x < calculated_length_y)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static int CalculatedLength(string word)
        {
            int string_length = word.Length;

            if (string_length % 2 == 0)
            {
                return 2 * string_length;
            }
            else
            {
                return string_length;
            }
        }
    }


  
}

