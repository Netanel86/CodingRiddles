using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonQuestions.linkedlist
{
    public class LinkedListSolutionsViewModel
    {
        private CustomList m_PredefinedList;

        public LinkedListSolutionsViewModel()
        {
            m_PredefinedList = new CustomList();
            m_PredefinedList.AddAll(new int[] { 23, 5, 3, 4, 64, 7, 90, 2, 15 });
        }

        public void ExecuteNthElementFromLinkedListTail(bool i_UsePredefinedList)
        {
            CustomList list = i_UsePredefinedList ?
                m_PredefinedList :
                ConsoleHelper.ScanComplexInput((str) => CustomList.Parse(str, ','), Strings.InputListMessage);
            int? pos = null;
            if (list != null)
            {
                Console.WriteLine("Your list values: {0}", list.ToString());
                pos = ConsoleHelper.ScanIntegerInput("Enter position from end of list to retrieve");
            }
            
            if (pos != null)
            {
                try
                {
                    int valInPos = LinkedListSolutions.GetValueInPositionFromEndOfLinkedList(list, (int)pos);
                    Console.WriteLine(Strings.NthFromTailResultMessage,
                        ConsoleHelper.GetIntAsPositionString((int)pos), valInPos);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine(Strings.ActionAbortedMessage);
            }

            ConsoleHelper.PrintContinueMessage();
        }
    }
}
