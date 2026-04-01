using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using PetStoreApiTest.Context;

namespace PetStoreApiTest.StepDefinitions
{
    [Binding]
    public class ResponseVerificationSteps
    {
        public ResponseVerificationSteps(ApiContext apiContext, ErrorResponseContext errorResponseContext)
        {
            ApiContext = apiContext;
            ErrorResponseContext = errorResponseContext;
        }

        public ApiContext ApiContext { get; }
        public ErrorResponseContext ErrorResponseContext { get; }

        [Then(@"There are a greater than (.*) number of responses")]
        public void ThenThereAreAGreaterThanNumberOfResponses(int expectedCountOfResponses)
        {
            ApiContext.Responses.Count.Should().BeGreaterThan(expectedCountOfResponses);
        }

        [Then(@"There is exactly (.*) response")]
        [Then(@"There are exactly (.*) responses")]
        public void ThenThereAreExactlyResponses(int expectedCountOfResponses)
        {
            ApiContext.Responses.Count.Should().Be(expectedCountOfResponses);
        }

        [Then(@"The responses have status code ""(.*)""")]
        public void ThenTheResponsesHaveStatusCode(HttpStatusCode expectedStatusCode)
        {
            using (new AssertionScope())
            {
                foreach (var response in ApiContext.Responses)
                {
                    response.StatusCode.Should().Be(expectedStatusCode);
                }
            }
        }

        [Then(@"The error response includes message ""(.*)""")]
        public void ThenTheErrorResponseIncludesMessage(string expectedMessage)
        {
            ErrorResponseContext.ErrorResponseMessage.Message.Should().Be(expectedMessage);
        }

        [Then(@"The error response includes code (.*)")]
        public void ThenTheErrorResponseIncludesCode(int expectedCode)
        {
            ErrorResponseContext.ErrorResponseMessage.Code.Should().Be(expectedCode);
        }
    }
}
