

namespace addressbook_tests_white
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITLE;
        protected AutoItX3 aux;
        public HelperBase (ApplicationManager manager) 
        {
            this.manager = manager;
            WINTITLE = ApplicationManager.WINTITLE;
            this.aux = manager.Aux;
        }
    }
}
