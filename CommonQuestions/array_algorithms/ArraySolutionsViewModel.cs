using System;
using System.Text;

namespace CommonQuestions
{
    public class ArraySolutionsViewModel
    {
        public const int STRONGEST_SUBSET_ID = 1;
        public const int STRONGEST_SUBSETS_SUMS_ID = 2;
        
        private int[] m_PredefinedArray;

        public ArraySolutionsViewModel()
        {
            m_PredefinedArray = new int[] { 5, -1, -3, -4, 3, -1, 4, -50 };
        }

        public void ExecuteStrongestSubsetAction(bool i_UsePredefinedArray, int i_ActionId)
        {
            ArrayAlgorithms.ArrayAns ans = null;

            int[] array = i_UsePredefinedArray ?
                m_PredefinedArray :
                ConsoleHelper.ScanComplexInput(parseInputString, Strings.InputListMessage);

            if (array != null)
            {
                Console.Write("Your array is: ");
                Console.WriteLine(arrayToString(array));

                switch (i_ActionId)
                {
                    case STRONGEST_SUBSET_ID:
                        ans = ArrayAlgorithms.GetStrongestSubSet(array);
                        Console.WriteLine(Strings.StrongestSubsetResultMessage,
                            ans.ResultVal,
                            arrayToString(ans.ResultArray)
                            );

                        int sum = ArrayAlgorithms.GetStrongestSubSetSum(array, 0, 0);
                        Console.WriteLine("strongest subset: {0}", sum);
                        break;

                    case STRONGEST_SUBSETS_SUMS_ID:
                        ans = ArrayAlgorithms.GetStrongestSubsetsSums(array);
                        Console.WriteLine(Strings.StrongestSubsetSumsResultMessage,
                            ans.ResultVal,
                            arrayToString(ans.ResultArray));
                        break;
                }
            }
            else
            {
                Console.WriteLine(Strings.ActionAbortedMessage);
            }

            ConsoleHelper.PrintContinueMessage();
        }

        public void ExecuteFibonacciInPosition()
        {
            int? pos = ConsoleHelper.ScanIntegerInput("Enter an element position in a fibonacci series");

            if (pos != null)
            {
                Console.WriteLine(Strings.FibonacciNthElementResultMessage,
                    ConsoleHelper.GetIntAsPositionString((int)pos),
                    ArrayAlgorithms.FibonacciRecursive((int)pos));
            }
            else
            {
                Console.WriteLine(Strings.ActionAbortedMessage);
            }

            ConsoleHelper.PrintContinueMessage();
        }

        private string arrayToString(int[] i_Array)
        {
            StringBuilder builder = new StringBuilder();
            foreach (int val in i_Array)
            {
                builder.AppendFormat("[{0}], ", val);
            }

            return builder.ToString();
        }

        private int[] parseInputString(string i_String)
        {
            string[] vals = i_String.Split(',');
            int[] array = new int[vals.Length];

            for (int i = 0; i < vals.Length; i++)
            {
                array[i] = Int32.Parse(vals[i]);
            }

            return array;
        }
    }
}
