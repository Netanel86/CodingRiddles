using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonQuestions
{
    public interface IMenu
    {
        void AddMenuOption(IMenuOption i_Option);
        void Execute();
    }
}
