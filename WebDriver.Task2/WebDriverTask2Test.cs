using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriver.Task2
{
    class WebDriverTask2Test
    {
        private IWebDriver driver;
        private IJavaScriptExecutor js;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("https://pastebin.com/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void webDriverTask1()
        {
            driver.FindElement(By.Id("postform-text")).SendKeys("git config --global user.name \"New Sheriff in Town\"" +
                                                                "\ngit reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")" +
                                                                "\ngit push origin master --force");

            IWebElement codeText = driver.FindElement(By.Id("postform-text"));

            {
                IWebElement dropdownHighlighting = driver.FindElement(By.Id("postform-format"));

                js.ExecuteScript("arguments[0].style.visibility='visible';", dropdownHighlighting);
                SelectElement selectElementHighlighting = new SelectElement(dropdownHighlighting);
                selectElementHighlighting.SelectByValue("8");


                IWebElement dropdownExpiration = driver.FindElement(By.Id("postform-expiration"));
                js.ExecuteScript("arguments[0].style.visibility='visible';", dropdownExpiration);
                SelectElement selectElementExpiration = new SelectElement(dropdownExpiration);
                selectElementExpiration.SelectByValue("10M");
            }

            string title = "how to gain dominance among developers";
            driver.FindElement(By.Id("postform-name")).SendKeys(title);

            IWebElement buttonSave = driver.FindElement(By.CssSelector("button[class='btn -big']"));
            buttonSave.Click();

            IWebElement titleAfterSave = driver.FindElement(By.CssSelector("body h1"));

            Assert.That(titleAfterSave.Text, Is.EqualTo(title));
        }
    }
}
