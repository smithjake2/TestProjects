using ArkkTest.Context;
using ArkkTest.PageObjectModel;

namespace ArkkTest.StepDefinitions
{
    [Binding]
    public class WorkflowsSteps
    {
        public WorkflowsSteps(WorkflowsPage workflowsPage)
        {
            WorkflowsPage = workflowsPage;
        }

        public WorkflowsPage WorkflowsPage { get; }

        [When(@"I Click To Create A New Schedule")]
        public async Task WhenIClickToCreateANewSchedule()
        {
            await WorkflowsPage.ClickWorkflowDropdown();
            await WorkflowsPage.ClickWorkflowDropdownCreateSchedule();
        }

    }
}
