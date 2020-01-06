using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;

namespace GoogleSheets.HelloWorld
{
    internal class Program
    {
        public const string _appName = "GoogleSheets.HelloWorld";

        private static void Main(string[] args)
        {
            var apiKey = AppSettings.SheetsApiKey;
            var docId = AppSettings.SheetsDocId;

            var service = new SheetsService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = _appName
            });

            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(docId, "A:B");

            ValueRange spreadsheet = request.Execute();

            IList<IList<object>> sheetData = spreadsheet.Values;
            foreach (IList<object> row in sheetData)
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
