using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        private GroupHelper groupHelper;
        private AutoItX3 aux;

        public ApplicationManager()
        {
            groupHelper = new GroupHelper(this);
            aux = new AutoItX3();
            aux.Run();
        }

        public void Stop()
        {

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
