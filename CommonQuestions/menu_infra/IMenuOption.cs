using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonQuestions
{
    public interface IMenuOption
    {
        string Description { get; }
        void Execute();
    }
}
