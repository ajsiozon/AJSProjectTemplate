using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AJSProjectTemplates.DL.AJSHelper
{
    public static class DataCompare
    {
        public static bool ExactMatch(string input, string match)
        {
            return Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(match)));

        }
    }
}
