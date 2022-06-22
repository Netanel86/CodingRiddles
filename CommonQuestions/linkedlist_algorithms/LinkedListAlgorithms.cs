using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonQuestions.linkedlist
{
    public class LinkedListSolutions
    {
        public static int GetValueInPositionFromEndOfLinkedList(CustomList i_List, int i_PositionFromEnd)
        {
            CustomList.Node curr = i_List.Head;
            CustomList.Node atPosition = i_List.Head;
            int index = 0;

            if (i_PositionFromEnd < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "i_PositionFromEnd",
                    String.Format(
                        "Illegal input {0}: a position can't be negative.",
                        i_PositionFromEnd)
                    );
            }

            while (curr != null)
            {
                index++;
                if (index > i_PositionFromEnd)
                {
                    atPosition = atPosition.Next;
                }
                curr = curr.Next;
            }

            if (index < i_PositionFromEnd)
            {
                throw new ArgumentOutOfRangeException(
                    "i_PositionFromEnd",
                    String.Format(
                        "The list size of {0} is too short for the requested position {1}!",
                        index,
                        i_PositionFromEnd)
                    );
            }

            return atPosition.Data;
        }
    }
}
