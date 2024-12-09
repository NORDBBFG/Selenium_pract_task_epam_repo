namespace Selenium_pract_task.FileHelper
{
    public static class EnvironmentVariableHelper
    {
        public static void EnsureEnvironmentVariableExist(string environmentVariableName, string environmentVariableState)
        {
            var headlessValue = Environment.GetEnvironmentVariable(environmentVariableName);

            if (string.IsNullOrEmpty(headlessValue))
            {
                Environment.SetEnvironmentVariable(environmentVariableName, environmentVariableState, EnvironmentVariableTarget.Process);
            }
        }
    }
}
