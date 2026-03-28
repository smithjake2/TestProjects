using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace ArkkTest.Context
{
    public class WebDriverContext
    {
        public IBrowser Browser => BrowserContext.Browser;
        public IBrowserContext BrowserContext { get; set; }
        public IPage Page { get; set; }
    }
}
