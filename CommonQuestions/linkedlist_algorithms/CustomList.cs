using System;
using System.Text;

namespace CommonQuestions
{
    public class CustomList
    {
        public static CustomList Parse(string i_String, char i_Separator)
        {
            CustomList list = new CustomList();
            string[] vals = i_String.Split(i_Separator);
            foreach (string val in vals)
            {
                list.Add(Int32.Parse(val));
            }

            return list;
        }

        public Node Head { get; private set; }

        public void Add(int i_Val)
        {
            if (Head == null)
            {
                Head = new Node(i_Val);
            }
            else
            {
                Node temp = Head;
                Node toAdd = new Node(i_Val);

                Head = toAdd;
                Head.Next = temp;
            }
        }
        public void AddAll(int[] i_Values)
        {
            foreach (int val in i_Values)
            {
                Add(val);
            }
        }

        public override string ToString()
        {
            Node curr = Head;
            StringBuilder builder = new StringBuilder();
            while (curr != null)
            {
                builder.AppendFormat("[{0}], ", curr.Data);
                curr = curr.Next;
            }

            return builder.ToString();
        }

        public class Node
        {
            public Node Next { get; set; }
            public int Data { get; set; }

            public Node(int i_Data)
            {
                Data = i_Data;
            }
        }
    }
}
