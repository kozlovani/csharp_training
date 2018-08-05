using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class ApplicationManager
    {
        private GroupHelper groupHelper;
        public static string WINTITLE = "Free Address Book";

        public ApplicationManager()
        {
            Application app = Application.Launch(@"C:\Tools\FreeAddressBookPortable\AddressBook.exe");
            MainWindow = app.GetWindow(WINTITLE);
            
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            MainWindow.Get<Button>("").Click();
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public Window MainWindow { get; private set; }
    }
   
}
