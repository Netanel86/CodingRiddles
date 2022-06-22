using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonQuestions.misc_algorithms
{
    public class MiscAlgorithms
    {
        /// <summary>
        /// Gets the number of ears in a bunny line, where odd bunnies has 2 ears and even bunnies has 3.
        /// </summary>
        /// <param name="bunnies">the number of bunnies in the line</param>
        /// <returns>The sum of ears in the bunny line</returns>
        public int BunnyEars2(int bunnies)
        {
            if (bunnies == 0)
            {
                return 0;
            }
            return BunnyEars2(bunnies - 1) + (bunnies % 2 == 0 ? 3 : 2);
        }
        public int sumDigits(int n)
        {

            if (n == 0) return 0; ;

            return sumDigits(n / 10) + (n % 10);

        }

        public int CountDigitInstance(int n, int val)
        {
            if (n == 0) return 0;

            return CountDigitInstance(n / 10, val) + (n % 10 == val ? 1 : 0);
        }
        public int CountDigitDoubleInstanceTwice(int n, int val)
        {
            if (n == 0) return 0;

            return CountDigitDoubleInstanceTwice(n / 10, val) + (n % 10 == 8 ? ((n / 10) % 10 == 8 ? 2 : 1) : 0);
        }

        public int PowerN(int i_Val, int i_Power)
        {
            if (i_Power == 0) return 1;
            return PowerN(i_Val, i_Power - 1) * i_Val;
        }
        public int CountChar(String i_String, char i_Char)
        {
            if (i_String == String.Empty)
            {
                return 0;
            }

            return CountChar(i_String.Substring(1), i_Char) + (i_String.ToCharArray()[0] == i_Char ? 1 : 0);
        }
        public int CountSubstring(String i_String, String i_Substring)
        {
            if (i_String.Length <= 1)
            {
                return 0;
            }
            return CountSubstring(i_String.Substring(1), i_Substring) +
                (i_String.StartsWith(i_Substring) ? 1 : 0);
        }
        public String ChangeCharXToY(String i_String, char i_ToReplace, char i_New)
        {
            if (i_String.Length == 0)
            {
                return i_String;
            }

            return (i_String.ToCharArray()[0] == i_ToReplace ? i_New : i_String.ToCharArray()[0]) +
                ChangeCharXToY(i_String.Substring(1), i_ToReplace, i_New);
        }
        public String ChangeSubStringXToY(String i_String, String i_ToReplace, String i_New)
        {
            if (i_String.Length == 0)
            {
                return i_String;
            }

            return i_String.StartsWith(i_ToReplace) ?
                      i_New + ChangeSubStringXToY(i_String.Substring(i_ToReplace.Length), i_ToReplace, i_New) :
                      i_String.Substring(0, 1) + ChangeSubStringXToY(i_String.Substring(1), i_ToReplace, i_New);

        }
        public String RemoveCharInstance(String i_String, char i_Char)
        {
            if (i_String.Length == 0)
            {
                return i_String;
            }

            return (i_String.ToCharArray()[0] == i_Char ? ' ' : i_String.ToCharArray()[0]) + RemoveCharInstance(i_String.Substring(1), i_Char);
        }
        public String AddCharSeperator(String i_String, char i_Seperator)
        {
            if (i_String.Length <= 1)
            {
                return i_String;
            }

            return i_String.ToCharArray()[0] + i_Seperator + AddCharSeperator(i_String.Substring(1), i_Seperator);
        }
        public String AddCharSeperatorIdenticalAdjacent(String i_String, char i_Seperator)
        {
            if (i_String.Length == 0)
            {
                return i_String;
            }
            char[] charArray = i_String.ToCharArray();

            return (i_String.Length > 1 && charArray[0] == charArray[1] ? charArray[0] + i_Seperator : charArray[0]) +
                AddCharSeperatorIdenticalAdjacent(i_String.Substring(1), i_Seperator);
        }
        public String MoveCharToEnd(String i_String, char i_MoveToEnd)
        {
            if (i_String.Length == 0)
            {
                return i_String;
            }
            char c = i_String.ToCharArray()[0];

            return c == 'x' ?
                    MoveCharToEnd(i_String.Substring(1), i_MoveToEnd) + 'x' :
                    c + MoveCharToEnd(i_String.Substring(1), i_MoveToEnd);
        }
        public int countPairs(String str)
        {
            if (str.Length < 3)
            {
                return 0;
            }
            char[] charArray = str.ToCharArray();

            return charArray[0] == charArray[2] ? 1 : 0 + countPairs(str.Substring(1));

        }
    }
}
