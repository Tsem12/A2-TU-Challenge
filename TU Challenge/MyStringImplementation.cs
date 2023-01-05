using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    public class MyStringImplementation
    {
        public static bool IsNullEmptyOrWhiteSpace(string input)
        {
            if(input == null)
                return true;

            for(int i = 0; i < input.Length; i++)
            {
                if (!char.IsWhiteSpace(input[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static string MixString(string a, string b)
        {
            if (IsNullEmptyOrWhiteSpace(a) || IsNullEmptyOrWhiteSpace(b))
                throw new ArgumentException();

            string result = "";

            for(int i = 0; i < MathF.Max(a.Length, b.Length); i++)
            {
                if(i < a.Length)
                {
                    result += a[i];
                }
                if(i < b.Length)
                {
                    result += b[i];
                }
            }

            return result;
        }

        public static string ToLowerCase(string a)
        {
            string result = "";
            
            foreach(char b in a)
            {
                if(b >= 'A' && b <= 'Z' || b >= 'À' && b <= 'Þ')
                {
                    result += (char) (b + 32);
                }
                else
                {
                    result += b;
                }
            }

            return result;

        }

        public static string Voyelles(string a)
        {
            string voyellesLower = "aeiouy";    
            string voyellesUpper = "AEIOUY";

            string result = "";

            foreach(char c in a)
            {
                for (int i = 0; i < voyellesLower.Length; i++)
                {
                    if (c == voyellesLower[i] || c == voyellesUpper[i])
                    {
                        if (!result.Contains(c))
                        {
                            result += voyellesLower[i];
                        }
                    }
                }
            }
            return result;
        }

        public static string Reverse(string a)
        {
            string result = "";
            for(int i = a.Length - 1; i >= 0; i--)
            {
                result += a[i];
            }
            return result;
        }

        public static string BazardString(string input)
        {
            string result = "";
            string stashedResult = "";

            for (int i = 0; i < input.Length; i++)
            {
                if(i%2 == 1)
                {
                    stashedResult += input[i];
                }
                else
                {
                    result += input[i];
                }
            }

            for(int i = 0; i < stashedResult.Length; i++)
            {
                result += stashedResult[i];
            }

            return result;
        }

        public static string UnBazardString(string input)
        {
            throw new NotImplementedException();
        }

        public static string ToCesarCode(string input, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
