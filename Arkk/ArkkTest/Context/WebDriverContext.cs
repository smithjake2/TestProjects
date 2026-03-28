namespace ArkkTest.Context
{
    public class WebDriverContext
    {
        public IBrowser Browser => BrowserContext.Browser;
        public IBrowserContext BrowserContext { get; set; }
        public IPage Page { get; set; }
    }
}
