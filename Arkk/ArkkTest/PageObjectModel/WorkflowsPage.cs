
using ArkkTest.Context;

namespace ArkkTest.PageObjectModel
{
    public class WorkflowsPage : BasePage
    {
        public WorkflowsPage(WebDriverContext webDriverContext) : base(webDriverContext) { }

        private ILocator WorkflowDropdown => Page.Locator(".mat-menu-trigger.details").First;
        private ILocator WorkflowDropdownCreateSchedule => Page.GetByRole(AriaRole.Menuitem, new() { Name = "Create Schedule" });
        private ILocator WorkflowDescription => Page.GetByText(" This is where you can schedule your workflows, edit their definitions, or create new ones. ");

        public async Task ClickWorkflowDropdown()
        {
            await WorkflowDropdown.ClickAsync();
        }

        public async Task ClickWorkflowDropdownCreateSchedule()
        {
            await WorkflowDropdownCreateSchedule.ClickAsync();
        }

        public async Task WaitForDescriptionToBeLoaded()
        {
            await Assertions.Expect(WorkflowDescription).ToBeVisibleAsync();
        }
    }
}
