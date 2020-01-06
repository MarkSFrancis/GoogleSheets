using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Threading;

namespace GoogleSheets.HelloWorld
{
    class Program
    {
        static readonly string[] _scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        public const string _appName = "GoogleSheets.HelloWorld";

        static void Main(string[] args)
        {
            var apiKey = AppSettings.SheetsApiKey;
            var docId = AppSettings.SheetsDocId;

            var service = new SheetsService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = _appName
            });

            var request = service.Spreadsheets.Values.Get(docId, "A:B");

            var spreadsheet = request.Execute();

            var sheetData = spreadsheet.Values;
            foreach (var row in sheetData)
            {
                foreach (var cell in row)
                {
                    Console.WriteLine(cell);
                }
            }
            Console.WriteLine();
            Console.ReadKey(true);
        }
    }
}
