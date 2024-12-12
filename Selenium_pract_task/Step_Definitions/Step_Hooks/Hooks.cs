using TechTalk.SpecFlow;
using static Selenium_pract_task.Constants.Constants.IOConstants;

namespace Selenium_pract_task.Step_Definitions.Step_Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [AfterScenario("@DeleteFile")]
        public static void DeleteFileTearDown()
        {
            string filePath = Path.Combine(windowsDefaultDownloadDirectoryPath, EPAMCorporateOverviewFileNeame);
            File.Delete(filePath);
        }
    }
}