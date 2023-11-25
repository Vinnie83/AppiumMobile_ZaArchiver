using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace ZaArchiver
{
    public class ZaArchiverTests
    {
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\ZArchiver_1.0.8_Apkpure.apk";

        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);
            this.driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), options);


        }

        [TearDown]

        public void CloseApp()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AddFirstTask()
        {
            var addFirstTask = driver.FindElementById("com.splendapps.splendo:id/fabAddTask");
            addFirstTask.Click();

            Thread.Sleep(3000);

            var inputTask = driver.FindElementById("com.splendapps.splendo:id/edtTaskName");
            inputTask.SendKeys("Pregled Ali");

            var inputDate = driver.FindElementById("com.splendapps.splendo:id/edtDueD");
            inputDate.Click();

            var inputDateCalendar = driver.FindElementByXPath("//android.view.View[@content-desc=\"17 November 2023\"]");
            inputDateCalendar.Click();

            var okButtonCalendar = driver.FindElementById("android:id/button1");
            okButtonCalendar.Click();

            var okButtonTask = driver.FindElementById("com.splendapps.splendo:id/fabSaveTask");
            okButtonTask.Click();

            Thread.Sleep(3000);

            var result = driver.FindElementById("com.splendapps.splendo:id/task_name");

            Assert.That(result.Text, Is.EqualTo("Pregled Ali"));


        }
    }
}