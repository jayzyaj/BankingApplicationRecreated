using System.Text.RegularExpressions;

namespace Helpers
{
    public class Helper
    {
        public static string CapitalizeFirstLetter(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        public static bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            return false;
        }

        public static bool ValidateContactNumber(string contactNumber)
        {
            Regex regex = new Regex(@"^(\+63|0)9\d{9}$");
            Match match = regex.Match(contactNumber);
            if (match.Success)
                return true;
            return false;
        }
    }
}