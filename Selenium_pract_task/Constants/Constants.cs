namespace Selenium_pract_task.Constants
{
    public static class Constants
    {
        public static class IOConstants
        {
            public static readonly string windowsDefaultDownloadDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            public static readonly string headlesStateEnvironmentVariableName = "HEADLESS";
            public static readonly string EPAMBaseUrl = "https://www.epam.com";
        }
    }
}
