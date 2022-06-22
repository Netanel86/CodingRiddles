using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonQuestions
{
    public class Menu : IMenu
    {
        private string m_Header;
        private string m_FormattedHeader { get { return ">|>| [ " + m_Header + " ] |<|<"; } }
        private const bool v_Legal = true;
        private const bool v_Aborted = true;

        private List<IMenuOption> m_Options;
        private bool m_IsAborted = !v_Aborted;

        public Menu(string i_Header)
        {
            m_Header = i_Header;
            m_Options = new List<IMenuOption>();
        }

        public void AddMenuOption(IMenuOption i_Option)
        {
            m_Options.Add(i_Option);
        }

        public void Execute()
        {
            while (!m_IsAborted)
            {
                printMenu();
                handleInput();
            }
            m_IsAborted = !v_Aborted;
        }

        private string backOrExit()
        {
            return this is IMenuOption ? "go back" : "exit";
        }

        private void handleInput()
        {
            bool isLegal = !v_Legal;

            Console.WriteLine("\nPress ENTER to select!");
            while (!isLegal)
            {
                Console.Write("Select an option to execute, 1 - {0}, or ENTER to {1}: ", m_Options.Count, backOrExit());

                string input = Console.ReadLine();
                int selection = 0;

                try
                {
                    selection = Int32.Parse(input);
                    if (selection <= m_Options.Count && selection > 0)
                    {
                        isLegal = v_Legal;
                        Console.Clear();
                        m_Options[selection - 1].Execute();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("the option entered ({0}) is out of range, the available options range is 1 - {1}",
                            selection,
                            m_Options.Count);
                        Console.Write("Press ENTER to try again...");
                        Console.ReadLine();
                    }

                }
                catch (FormatException ex)
                {
                    //text was entered, console closes
                    isLegal = v_Legal;
                    m_IsAborted = v_Aborted;
                }
            }
        }

        private void printMenu()
        {
            printHeader();

            Console.WriteLine("Available options:\n");
            for (int i = 0; i < m_Options.Count; i++)
            {
                Console.WriteLine("[{0}] >> {1} <<", i + 1, m_Options[i].Description);
            }
        }
        private void printHeader()
        {
            if (m_Header != null)
            {
                Console.WriteLine(m_FormattedHeader);
                Console.WriteLine();
            }
        }
    }
}
