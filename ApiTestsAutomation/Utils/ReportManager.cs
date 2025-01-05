namespace ApiTestsAutomation.Utils
{
    public class ReportManager
    {
        private static string _reportFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
        private static string _reportFilePath = Path.Combine(_reportFolderPath, "test-report.html");

        public static void InitializeReport()
        {
            if (!Directory.Exists(_reportFolderPath))
            {
                Directory.CreateDirectory(_reportFolderPath);
            }

            using (StreamWriter writer = new StreamWriter(_reportFilePath, append: false))
            {
                writer.WriteLine("<html>");
                writer.WriteLine("<head>");
                writer.WriteLine("<style>");
                writer.WriteLine("body { font-family: Arial, sans-serif; }");
                writer.WriteLine("table { width: 100%; border-collapse: collapse; }");
                writer.WriteLine("th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
                writer.WriteLine("th { background-color: #f2f2f2; }");
                writer.WriteLine("</style>");
                writer.WriteLine("</head>");
                writer.WriteLine("<body>");
                writer.WriteLine("<h2>Test Report</h2>");
                writer.WriteLine("<table>");
                writer.WriteLine("<tr><th>Test Name</th><th>Status</th><th>Timestamp</th></tr>");
            }
        }

        public static void AppendTestResult(string testName, string status)
        {
            using (StreamWriter writer = new StreamWriter(_reportFilePath, append: true))
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string statusClass = status == "Passed" ? "style='color: green;'" :
                                     status == "Failed" ? "style='color: red;'" :
                                     "style='color: orange;'";
                writer.WriteLine($"<tr><td>{testName}</td><td {statusClass}>{status}</td><td>{timestamp}</td></tr>");
            }
        }

        public static void FinalizeReport()
        {
            using (StreamWriter writer = new StreamWriter(_reportFilePath, append: true))
            {
                writer.WriteLine("</table>");
                writer.WriteLine("</body>");
                writer.WriteLine("</html>");
            }
        }
    }
}
