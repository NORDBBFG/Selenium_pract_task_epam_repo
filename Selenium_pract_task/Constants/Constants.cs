using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_pract_task.Constants
{
    public static class Constants
    {
        public static class IOConstants
        {
            public static readonly string windowsDefaultDownloadDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        }
    }
}
