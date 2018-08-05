using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManagmentMenuHelper : HelperBase
    {
        public ManagmentMenuHelper(ApplicationManager manager) : base(manager)
        {
            
        }

        public void GoToManageOverviewPage()
        {
            driver.Url = baseUrl+ "/manage_overview_page.php";
        }

        public void GotoManageProjectPage()
        {
            driver.Url =  baseUrl+ "/manage_proj_page.php";
        }
    }
}
