namespace Selenium_pract_task.Constants
{
    public static class Constants
    {
        public static class IOConstants
        {
            public static readonly string windowsDefaultDownloadDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            public static readonly string defaultJsonSchemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Endpoints");
            public const string EPAMCorporateOverviewFileNeame = "EPAM_Corporate_Overview_Q4_EOY.pdf";
            public static readonly string headlesStateEnvironmentVariableName = "HEADLESS";
            public const string userApiEndpoint = "https://jsonplaceholder.typicode.com";
        }
    }
}
