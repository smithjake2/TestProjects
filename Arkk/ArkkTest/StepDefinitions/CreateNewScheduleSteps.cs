using ArkkTest.Context;
using ArkkTest.PageObjectModel;

namespace ArkkTest.StepDefinitions
{
    [Binding]
    public class CreateNewScheduleSteps
    {
        public CreateNewScheduleSteps(CreateNewSchedulePage createNewSchedulePage, WorkflowsPage workflowsPage)
        {
            CreateNewSchedulePage = createNewSchedulePage;
            WorkflowsPage = workflowsPage;
        }

        public CreateNewSchedulePage CreateNewSchedulePage { get; }
        public WorkflowsPage WorkflowsPage { get; }

        [When(@"I Create A New Schedule With Basic Information")]
        public async Task WhenICreateANewScheduleWithBasicInformation()
        {
            await CreateNewSchedulePage.EnterName("test");

            await CreateNewSchedulePage.ClickPeriodDropdown();
            await CreateNewSchedulePage.ClickPeriodOption();

            await CreateNewSchedulePage.ClickEntitiesDropdown();
            await CreateNewSchedulePage.ClickEntitiesOption();

            await CreateNewSchedulePage.ClickRunFrequencyDropdown();
            await CreateNewSchedulePage.ClickRunFrequencyOption();

            await CreateNewSchedulePage.ClickPeriodValuesDropdown();
            await CreateNewSchedulePage.ClickPeriodValuesOption();

            await CreateNewSchedulePage.ClickScheduleCTA();
            await CreateNewSchedulePage.ClickContinueConfirmSchedule();

            await WorkflowsPage.WaitForDescriptionToBeLoaded();
        }

    }
}
