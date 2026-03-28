using System.Text.RegularExpressions;
using ArkkTest.Context;

namespace ArkkTest.PageObjectModel
{
    public class CreateNewSchedulePage : BasePage
    {
        public CreateNewSchedulePage(WebDriverContext webDriverContext) : base(webDriverContext) { }

        private ILocator Name => Page.GetByRole(AriaRole.Textbox).First;
        private ILocator PeriodDropdown => Page.Locator("dropdown-rp3").Filter(new() { HasText = "M25 Monthly" });
        private ILocator PeriodOption => Page.GetByText("M25 Monthly");
        private ILocator EntitiesDropdown => Page.Locator("mult-dropdown");
        private ILocator EntitiesOption => Page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Jake$") }).Nth(3);
        private ILocator RunFrequencyDropdown => Page.Locator("dropdown-rp3").Filter(new() { HasText = "Indefinitely Once Set number" });
        private ILocator RunFrequencyOption => Page.GetByText("Once");
        private ILocator PeriodValuesDropdown => Page.Locator("div").Filter(new() { HasTextRegex = new Regex("^M3$") }).First;
        private ILocator PeriodValuesOption => Page.GetByText("1st Apr 2026 → 30th Apr");
        private ILocator ScheduleCTA => Page.GetByRole(AriaRole.Button, new() { Name = "Schedule" });
        private ILocator ConfirmScheduleContinue => Page.Locator("#idNewPlanModal").GetByText("Continue", new() { Exact = true });

        public async Task ClickPeriodDropdown()
        {
            await PeriodDropdown.ClickAsync();
        }

        public async Task ClickPeriodOption()
        {
            await PeriodOption.ClickAsync();
        }

        public async Task ClickEntitiesDropdown()
        {
            await EntitiesDropdown.ClickAsync();
        }

        public async Task ClickEntitiesOption()
        {
            await EntitiesOption.ClickAsync();
        }

        public async Task ClickRunFrequencyDropdown()
        {
            await RunFrequencyDropdown.ClickAsync();
        }

        public async Task ClickRunFrequencyOption()
        {
            await RunFrequencyOption.ClickAsync();
        }

        public async Task ClickPeriodValuesDropdown()
        {
            await PeriodValuesDropdown.ClickAsync();
        }

        public async Task ClickPeriodValuesOption()
        {
            await PeriodValuesOption.ClickAsync();
        }

        public async Task ClickScheduleCTA()
        {
            await ScheduleCTA.ClickAsync();
        }

        public async Task ClickContinueConfirmSchedule()
        {
            await ConfirmScheduleContinue.ClickAsync();
        }

        public async Task EnterName(string name)
        {
            await Name.FillAsync(name);
        }

    }
}
