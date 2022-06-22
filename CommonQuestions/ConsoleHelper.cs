using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonQuestions
{
    public class ConsoleHelper
    {
        public static void PrintContinueMessage()
        {
            Console.Write(Strings.EnterToContinueMessage);
            Console.ReadLine();
        }

        public static string GetIntAsPositionString(int i_Position)
        {
            return i_Position == 1 ?
                "1st" : i_Position == 2 ?
                "2nd" : i_Position == 3 ?
                "3rd" : String.Format("{0}th", i_Position);

        }

        public static int? ScanIntegerInput(string i_UserMessage)
        {
            const bool v_Legal = true;
            const bool v_Aborted = true;
            bool isLegalOrAborted = !v_Legal;
            int? input = null;

            while (!isLegalOrAborted)
            {
                Console.Write(i_UserMessage + ", or leave empty to abort:");
                string str = Console.ReadLine();
                if (!String.IsNullOrEmpty(str))
                {
                    try
                    {
                        input = Int32.Parse(str);
                        isLegalOrAborted = v_Legal;
                    }
                    catch (FormatException i_Ex)
                    {
                        Console.WriteLine(i_Ex.Message + " " + Strings.IntegerFormatErrorMessage);
                        PrintContinueMessage();
                    }
                }
                else
                {
                    isLegalOrAborted = v_Aborted;
                }
            }
            return input;
        }

        /// <summary>
        /// Scan's a string input from the user, parses and returns 
        /// a <typeparamref name="T"/> type object, the method handles illegal input.
        /// </summary>
        /// <typeparam name="T">Represents the result type to be parsed from the string input</typeparam>
        /// <param name="i_Parser">
        /// A <see cref="Func{T, TResult}"/> that recieves an input string, 
        /// and parses it to type of the result object <typeparamref name="T"/>.
        /// To use the built in input verification, method should 
        /// throw a <see cref="FormatException"/> in case of illegal input.
        /// </param>
        /// <param name="i_UserMessage">An input message to display to the user</param>
        /// <returns>A <typeparamref name="T"/> type object which represents the parsed output</returns>
        public static T ScanComplexInput<T>(Func<string, T> i_Parser, string i_UserMessage)
        where T : class
        {
            ValidateNull(i_Parser, "i_Parser");

            const bool v_Aborted = true;
            const bool v_Legal = true;
            bool isLegalOrAborted = !v_Aborted;
            T result = null;
            while (!isLegalOrAborted)
            {
                Console.WriteLine(i_UserMessage + ", or leave empty to abort:");
                string input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    try
                    {
                        result = i_Parser.Invoke(input);
                        isLegalOrAborted = v_Legal;
                    }
                    catch (FormatException i_Ex)
                    {
                        Console.WriteLine(i_Ex.Message + " " + Strings.IntegerFormatErrorMessage);
                        PrintContinueMessage();
                        Console.Clear();
                    }
                }
                else
                {
                    isLegalOrAborted = v_Aborted;
                }
            }

            return result;
        }

        public static void ValidateNull(object i_Object, string i_ParamName)
        {
            if(i_Object == null)
            {
                throw new ArgumentNullException(i_ParamName, "Can't be null");
            }
        }
    }

    
}
