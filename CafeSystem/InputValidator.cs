using System.Text.RegularExpressions;

namespace CafeSystem
{
    public class InputValidator
    {
        public static bool ValidateName(string name)
        {
            string pattern = @"^[a-zA-Z]+$";   
            return Regex.IsMatch(name, pattern);
        }

        public static bool ValidatePhoneNumber(string phone)
        {
            string phonePattern = @"^\d{11}$";  
            return Regex.IsMatch(phone, phonePattern);
        }

        public static bool ValidateSNN(string snn)
        {
            string snnPattern = @"^\d+$";  
            return Regex.IsMatch(snn, snnPattern);
        }

        public static bool ValidateEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public static bool ValidatePositiveNumber(int number)
        {
            return number > 0;
        }
    }
}
