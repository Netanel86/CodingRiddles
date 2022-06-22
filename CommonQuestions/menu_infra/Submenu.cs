using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonQuestions
{
    public class Submenu : Menu, IMenuOption
    {
        public string Description { get; private set; }

        public Submenu(string i_Header, string i_Description) 
            : base(i_Header)
        {
            Description = i_Description;
        }
    }
}
