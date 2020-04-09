using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace OmsisWebApp
{
    /// <summary>
    /// Helper class.
    /// </summary>
    public class Tools
    {
        NumberFormatInfo formatProvider = NumberFormatInfo.InvariantInfo;
        StringComparison comparison = StringComparison.InvariantCulture;

        /// <summary>
        /// Convert string type to DataTime type.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public DateTime ToTime(string filename)
        {
            string _Year;
            string _Month;
            string _Day;
            string _Hour;
            string _Minute;
            string _Second;

            Regex regexDay = new Regex(@"^(\d{0,4})(\d{0,2})(\d{0,2})_", (RegexOptions)11);
            Regex regexHour = new Regex(@"_(\d{0,2})(\d{0,2})(\d{0,2})_", (RegexOptions)11);

            string[] s = filename.Split("_".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            Match match = regexDay.Match(filename);
            _Year = match.Groups[1].Value;
            _Month = match.Groups[2].Value;
            _Day = match.Groups[3].Value;
            match = regexHour.Match(filename);
            _Hour = match.Groups[1].Value;
            _Minute = match.Groups[2].Value;
            _Second = match.Groups[3].Value;

            DateTime dateTime = new DateTime(int.Parse(_Year, formatProvider), int.Parse(_Month, formatProvider), int.Parse(_Day, formatProvider),
                int.Parse(_Hour, formatProvider), int.Parse(_Minute, formatProvider), int.Parse(_Second, formatProvider));
            return dateTime;
        }

        public static bool IsDateTime(string str)
        {
            return new Regex(@"^\d{2,2}\.\d{2,2}\.\d{4,4}\s\d{2,2}\:\d{2,2}\:\d{2,2}$", (RegexOptions)11).IsMatch(str) ? true : false;
        }

        public static bool IsDerectory(string path)
        {
            if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Output to console stylise text.
        /// </summary>
        /// <param name="s">String for output</param>
        public static void Green(string s)
        {
            ConsoleColor cc = Console.ForegroundColor;
            ConsoleColor bc = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(s);
            Console.ForegroundColor = cc;
            Console.BackgroundColor = bc;
        }
        /// <summary>
        /// Output to console stylise text.
        /// </summary>
        /// <param name="s">String for output</param>
        public static void Yellow(string s)
        {
            ConsoleColor cc = Console.ForegroundColor;
            ConsoleColor bc = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            Console.ForegroundColor = cc;
            Console.BackgroundColor = bc;
        }
        /// <summary>
        /// Output to console stylise text.
        /// </summary>
        /// <param name="s">String for output</param>
        public static void Red(string s)
        {
            ConsoleColor cc = Console.ForegroundColor;
            ConsoleColor bc = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(s);
            Console.ForegroundColor = cc;
            Console.BackgroundColor = bc;
        }
        /// <summary>
        /// Output to console stylise text.
        /// </summary>
        /// <param name="s">String for output</param>
        public static void YellowBlue(string s)
        {
            ConsoleColor cc = Console.ForegroundColor;
            ConsoleColor bc = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(s);
            Console.ForegroundColor = cc;
            Console.BackgroundColor = bc;
        }
        /// <summary>
        /// Output to console stylise text.
        /// </summary>
        /// <param name="s">String for output</param>
        public static void GreenYellow(string s)
        {
            ConsoleColor cc = Console.ForegroundColor;
            ConsoleColor bc = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(s);
            Console.ForegroundColor = cc;
            Console.BackgroundColor = bc;
        }
    }
}
