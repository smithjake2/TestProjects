using ArkkTest.Context;
using ArkkTest.PageObjectModel;

namespace ArkkTest.StepDefinitions
{
    [Binding]
    public sealed class VerificationSteps
    {
        public ProcessInstancePage ProcessInstancePage { get; }

        public VerificationSteps(ProcessInstancePage processInstancePage)
        {
            ProcessInstancePage = processInstancePage;
        }

        [Then(@"I Verify The Data In The Table:")]
        public async Task ThenIVerifyTheDataInTheTable(IEnumerable<SQLTransformedData> expectedSQLTransformedData)
        {
            var actualSQLTransformedData = await ProcessInstancePage.GetRowsAndData();

            Assert.That(expectedSQLTransformedData.Count() == actualSQLTransformedData.Count());

            for (int i = 0; i < actualSQLTransformedData.Count(); i++)
            {
                var expectedData = expectedSQLTransformedData.ToList()[i];
                var actualData = actualSQLTransformedData.ToList()[i];

                Assert.That(expectedData.Equals(actualData));
            }
        }

    }
}
