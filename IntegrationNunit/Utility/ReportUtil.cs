using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using static System.IO.Directory;
using ExtentReport = AventStack.ExtentReports.ExtentReports;

namespace NunitTests.Utility
{
    public class ReportUtil
    {
        [ThreadStatic] public static ExtentTest Test;
        ExtentReport extent = new();

        public void StartReport()
        {
            var reportPath = GetParent(@"../../../")?.FullName + "//Result//Result_" +
                             DateTime.Now.ToString("ddMMyyyy") + "//";

            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent.AttachReporter(htmlReporter);
        }

        public void CreateTest()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var index = testName.IndexOf('(');
            if (index > 0) testName = testName.Substring(0, index);
            testName = Regex.Replace(testName, "[A-Z]", " $0");
            Test = extent.CreateTest(testName);
        }

        public void LogApiResponse(string apiResponse)
        {
            Test.Info($"Response : ${apiResponse}");
        }

        public void LogTestStatus()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;
            string stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? string.Empty
                : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            Status logStatus = status switch
            {
                TestStatus.Failed => Status.Fail,
                TestStatus.Inconclusive => Status.Warning,
                TestStatus.Skipped => Status.Skip,
                _ => Status.Pass,
            };

            Test.Log(logStatus, $"Test status: {logStatus}<br> {message}<br><br> {stacktrace}");
            var parameter = TestContext.CurrentContext.Test.Arguments;

            foreach (var obj in parameter)
            {
                switch (obj)
                {
                    case null:
                        continue;
                    case string:
                        Test.Info($"Parameter: {obj}");
                        continue;
                }


                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(obj);
                    var objectDump = ObjectDumper.Dump(value);
                    Test.Info($"{name}: {objectDump}");
                }
            }

            SaveTestDataToTheReport();
        }

        private void SaveTestDataToTheReport() => extent.Flush();
    }
}