using System.Text.RegularExpressions;

namespace DietitianTrackingSystemApp.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts first char to lower and adds rest of the string as same.
        /// </summary>
        /// <param name="text">the string that will be first-char-lowered.</param>
        /// <returns></returns>
        public static string FirstCharToLower(this string text)
        {
            return Char.ToLowerInvariant(text[0]) + text.Substring(1);
        }

        public static string TakeOnlyNums(this object value)
        {
            string resultString = "";

            try
            {
                Regex regexObj = new Regex(@"[^\d]");

                resultString = regexObj.Replace(value.ToString(), "");
            }
            catch (Exception Ex)
            {
                resultString = "";
            }

            return resultString;
        }
    }
}
