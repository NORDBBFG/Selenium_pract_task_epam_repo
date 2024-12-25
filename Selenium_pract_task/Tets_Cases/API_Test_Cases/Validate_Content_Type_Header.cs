using NUnit.Framework;
using Selenium_pract_task.Endpoints;
using Selenium_pract_task.Entities.AbstractEntities;
using static Selenium_pract_task.Logger.Logger;

namespace Selenium_pract_task.Tets_Cases.API_Test_Cases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("API")]
    public class Validate_Content_Type_Header : BaseApiTest
    {
        private UsersEndpoint _usersEndpoint = new UsersEndpoint();

        [Test]
        public void ValidateContentTypeHeaderTest()
        {
            var logger = GetLogger();
            logger.Information("Starting ValidateContentTypeHeaderTest.");

            var response = _usersEndpoint.GetUsersResponse();
            _usersEndpoint.ValidateContentTypeHeader(response);

            logger.Information("ValidateContentTypeHeaderTest passed successfully.");
        }
    }
}
