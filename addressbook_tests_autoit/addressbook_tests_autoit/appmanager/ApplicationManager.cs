using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        private GroupHelper groupHelper;
        private AutoItX3 aux;
        public static string WINTITLE = "Free Address Book";

        public ApplicationManager()
        {
            
            aux = new AutoItX3();
            aux.Run(@"C:\Tools\FreeAddressBookPortable\AddressBook.exe","",aux.SW_SHOW);
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }
    }
   
}
