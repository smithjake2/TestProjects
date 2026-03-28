using System.Diagnostics.CodeAnalysis;
using ArkkTest.Context;
using SpecFlow.Internal.Json;

namespace ArkkTest.PageObjectModel
{
    public class ProcessInstancePage : BasePage
    {
        public ProcessInstancePage(WebDriverContext webDriverContext) : base(webDriverContext) { }

        private ILocator FileUploadBox => Page.GetByRole(AriaRole.Button, new() { Name = "Choose File" });
        private ILocator UploadActivityOptionBox => Page.GetByRole(AriaRole.Heading, new() { Name = "Upload Activity V3" });
        private ILocator SQLTransformActivityBox => Page.GetByRole(AriaRole.Heading, new() { Name = "SQL Transform Activity V3" });
        private IFrameLocator TableIFrame => Page.Locator("iframe").Nth(1).ContentFrame;
        private ILocator TableCells => TableIFrame.GetByRole(AriaRole.Cell);

        private ILocator TableVisibleVerifier => TableIFrame.GetByText("Table:");

        public async Task GoToUploadActivitySection()
        {
            await UploadActivityOptionBox.ClickAsync();
        }

        public async Task GoToSQLTransformActivitySection()
        {
            await SQLTransformActivityBox.ClickAsync();
        }

        public async Task<IEnumerable<SQLTransformedData>> GetRowsAndData()
        {
            await Assertions.Expect(TableVisibleVerifier).ToBeVisibleAsync();

            var count = await TableCells.CountAsync();

            var rows = new List<SQLTransformedData>();
            var data = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var toAdd = await TableCells.Nth(i).InnerTextAsync();
                data.Add(toAdd);

                if (i % 9 == 8)
                {
                    var sqlTransformedData = new SQLTransformedData(data);

                    rows.Add(sqlTransformedData);
                    data.Clear();
                }
            }
            
            return rows;
        }
    }
}
