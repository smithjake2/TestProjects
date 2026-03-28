using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArkkTest.Context;
using Microsoft.Playwright;

namespace ArkkTest.PageObjectModel
{
    public abstract class BasePage
    {
        protected BasePage(WebDriverContext webDriverContext)
        {
            WebDriverContext = webDriverContext;
        }
        protected WebDriverContext WebDriverContext { get; }
        protected IPage Page => WebDriverContext.Page;
    }
}
