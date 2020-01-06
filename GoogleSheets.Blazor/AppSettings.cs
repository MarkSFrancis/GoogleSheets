namespace GoogleSheets.Blazor
{
    using static System.Environment;

    public static class AppSettings
    {
        public const string _sheetsApiKey = "SHEETS_API_KEY";
        public static string SheetsApiKey => GetEnvironmentVariable(_sheetsApiKey);

        public const string _sheetsDocId = "SHEETS_DOC_ID";
        public static string SheetsDocId => GetEnvironmentVariable(_sheetsDocId);
    }
}
