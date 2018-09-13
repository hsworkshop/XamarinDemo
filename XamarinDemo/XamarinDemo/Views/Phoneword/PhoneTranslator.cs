using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinDemo.Views.Phoneword
{
   public static class PhoneTranslator
    {
        public static string ToNumber(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return null;

            str = str.ToUpperInvariant();

            var num = new StringBuilder();

            foreach(var c in str)
            {
                if ("1234567890".Contains(c))
                {
                    num.Append(c);
                }
                else
                {
                    var ret = TranslateToNumber(c);
                    if(ret != null)
                        num.Append(ret);
                }
            }

            return num.ToString();
        }

        static readonly string[] digtis = {
             "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        static int? TranslateToNumber(char c)
        {
            for(int i =0; i < digtis.Length; i++)
            {
                if (digtis[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}
