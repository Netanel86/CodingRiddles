using CommonQuestions.linkedlist;
using CommonQuestions.menu_infra;

namespace CommonQuestions
{
    class Program
    {
        private static ArraySolutionsViewModel m_SubsetSolutionsVM;
        private static LinkedListSolutionsViewModel m_ListSolutionsVM;

        private const bool v_Predefined = true;

        static void Main(string[] args)
        {
            m_SubsetSolutionsVM = new ArraySolutionsViewModel();
            m_ListSolutionsVM = new LinkedListSolutionsViewModel();

            Menu mainMenu = new Menu(Strings.MainMenuHeader);

            mainMenu.AddMenuOption(BuildNthValFromTailSubmenu());
            mainMenu.AddMenuOption(BuildArrayAlgorithmsMenu());

            mainMenu.Execute();
        }

        static Submenu BuildArrayAlgorithmsMenu()
        {
            Submenu submenu = new Submenu(
                Strings.ArrayAlgorithmsMenuHeader,
                Strings.ArrayAlgorithmsMenuDescription);

            MenuOption fibonacci = new MenuOption(Strings.FibonacciNthElementMenuTitle, m_SubsetSolutionsVM.ExecuteFibonacciInPosition);

            submenu.AddMenuOption(BuildStrongestSubsetMenu());
            submenu.AddMenuOption(BuildStrongestSubsetsSumsMenu());
            submenu.AddMenuOption(fibonacci);

            return submenu;
        }

        static Submenu BuildStrongestSubsetMenu()
        {
            Submenu submenu = new Submenu(
                Strings.StrongestSubsetHeader,
                Strings.StrongestSubestMenuTitle);

            MenuOption customOption = new MenuOption(
                Strings.InputCustomMenuTitle,
                () => m_SubsetSolutionsVM
                .ExecuteStrongestSubsetAction(!v_Predefined, ArraySolutionsViewModel.STRONGEST_SUBSET_ID)
                );

            MenuOption predefOption = new MenuOption(
                Strings.InputPredefinedMenuTitle,
                () => m_SubsetSolutionsVM
                .ExecuteStrongestSubsetAction(v_Predefined, ArraySolutionsViewModel.STRONGEST_SUBSET_ID)
                );

            submenu.AddMenuOption(customOption);
            submenu.AddMenuOption(predefOption);

            return submenu;

        }

        static Submenu BuildStrongestSubsetsSumsMenu()
        {
            Submenu submenu = new Submenu(
                Strings.StrongestSubsetSumsHeader,
                Strings.StrongestSubsetSumsMenuTitle);

            MenuOption customOption = new MenuOption(
                Strings.InputCustomMenuTitle,
                () => m_SubsetSolutionsVM
                .ExecuteStrongestSubsetAction(!v_Predefined, ArraySolutionsViewModel.STRONGEST_SUBSETS_SUMS_ID)
                );

            MenuOption predefOption = new MenuOption(
                Strings.InputPredefinedMenuTitle,
                () => m_SubsetSolutionsVM
                .ExecuteStrongestSubsetAction(v_Predefined, ArraySolutionsViewModel.STRONGEST_SUBSETS_SUMS_ID)
                );

            submenu.AddMenuOption(customOption);
            submenu.AddMenuOption(predefOption);

            return submenu;
        }

        static Submenu BuildNthValFromTailSubmenu()
        {
            Submenu nthValFromTailOfListSubMenu = new Submenu(
                Strings.NthFromTailHeader,
                Strings.NthFromTailMenuTitle);

            MenuOption customOption = new MenuOption(
                Strings.InputCustomMenuTitle,
                () => m_ListSolutionsVM.ExecuteNthElementFromLinkedListTail(!v_Predefined)
                );

            MenuOption predefOption = new MenuOption(
                Strings.InputPredefinedMenuTitle,
                () => m_ListSolutionsVM.ExecuteNthElementFromLinkedListTail(v_Predefined)
                );

            nthValFromTailOfListSubMenu.AddMenuOption(customOption);
            nthValFromTailOfListSubMenu.AddMenuOption(predefOption);

            return nthValFromTailOfListSubMenu;
        }
    }

    

    
    
}
