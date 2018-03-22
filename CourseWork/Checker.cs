using System.Text.RegularExpressions;

namespace CourseWork
{
    public static class Checker
    {
        public static bool IsHouseNumber(string s)
        {
            return (new Regex("^[1-9][0-9]*[А-Я]?$").IsMatch(s));
        }
        public static bool IsName(string s)
        {
            return (new Regex(@"^[А-ЯA-Z][\w\s]+$").IsMatch(s));
        }
        public static bool IsFIO(string s)
        {
            return (new Regex("^[А-Я][а-я]+ [А-Я][а-я]+ [А-Я][а-я]+$").IsMatch(s));
        }
        public static bool IsNumber(string s)
        {
            return int.TryParse(s, out int result)&&result>0;
        }
        public static bool IsPhoneNumber(string s) => IsNumberAr(s);
        private static bool IsNumberAr(string s)
        {
            return (new Regex(@"^\d+$")).IsMatch(s);
        }
        public static bool IsPassportNumber(string s)
        {
            return  IsNumberAr(s)&& s.Length == 10;
        }
        public static bool IsINN(string s)
        {
            return IsNumberAr(s) && s.Length == 10;
        }
    }
}