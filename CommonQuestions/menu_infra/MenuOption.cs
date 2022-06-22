using System;

namespace CommonQuestions.menu_infra
{
    public class MenuOption : IMenuOption
    {
        private Action m_MenuAction;
        public string Description { get; private set; }

        public MenuOption(string i_Description,Action i_MenuAction)
        {
            Description = i_Description;
            m_MenuAction = i_MenuAction;
        }

        public void Execute()
        {
            m_MenuAction?.Invoke();
        }
    }
}
