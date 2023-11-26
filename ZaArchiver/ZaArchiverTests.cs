using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System.Diagnostics;

namespace ZaArchiver
{
    public class ZaArchiverTests
    {
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\ZArchiver_1.0.8_Apkpure.apk";
        private string downloadDirectoryPath = "/storage/emulated/0/Download";
        private string downloadRomDirectoryPath = "/storage/emulated/0/Download/downloaded_rom";
        private string fileName = "4_1.pdf";

        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);
            options.AddAdditionalCapability("appPackage", "ru.zdevs.zarchiver");
            options.AddAdditionalCapability("appActivity", "ru.zdevs.zarchiver.ZArchiver");
            this.driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), options);
           

        }

        [TearDown]

        public void CloseApp()
        {
            driver.Quit();
        }

        [Test]
        public void Test_ArchiveFile()
        {

            var allowWindow = driver.FindElementById("com.android.permissioncontroller:id/permission_allow_button");
            allowWindow.Click();   
            
            Thread.Sleep(3000);

            var okAllowButton = driver.FindElementById("android:id/button1");
            okAllowButton.Click();

            Thread.Sleep(5000);

            var downloadFolder = driver.FindElementByXPath("//android.widget.RelativeLayout[11]");
            downloadFolder.Click();

            Thread.Sleep(5000);

            var fileToArchive = driver.FindElementByXPath("//android.widget.RelativeLayout[6]");
            fileToArchive.Click();

            var compressButton = driver.FindElementByXPath("//android.widget.RelativeLayout[4]/android.widget.TextView");
            compressButton.Click();

            Thread.Sleep(5000);

            var buttonPath = driver.FindElementById("ru.zdevs.zarchiver:id/btn_path");
            buttonPath.Click();

            Thread.Sleep(5000);

            var folderDocuments = driver.FindElementByXPath("//android.widget.LinearLayout[11]/android.widget.TextView");
            folderDocuments.Click();

            var folderDownloadRom = driver.FindElementByXPath("//android.widget.LinearLayout[3]/android.widget.TextView");
            folderDownloadRom.Click();

            var okButtonDoc = driver.FindElementById("android:id/button1");
            okButtonDoc.Click();

            var okButtonFinal = driver.FindElementById("android:id/button1");
            okButtonFinal.Click();

            Thread.Sleep(5000);

            var folderRomNew = driver.FindElementByXPath("//android.widget.RelativeLayout[3]");
            folderRomNew.Click();

            Thread.Sleep(5000);

            var archivedFile = driver.FindElementByXPath("//android.widget.ListView/android.widget.RelativeLayout[2]");
            archivedFile.Click();

            Thread.Sleep(5000);

            var extractHere = driver.FindElementByXPath("//android.widget.RelativeLayout[2]/android.widget.TextView");
            extractHere.Click();

            // Get file paths
            string originalFilePath = Path.Combine(downloadDirectoryPath, fileName);
            string extractedFilePath = Path.Combine(downloadRomDirectoryPath, fileName);

            // Assert that both files exist
            Assert.IsTrue(File.Exists(originalFilePath), $"File {fileName} does not exist in {downloadDirectoryPath}.");
            Assert.IsTrue(File.Exists(extractedFilePath), $"File {fileName} does not exist in {downloadRomDirectoryPath}.");

        }
    }
}