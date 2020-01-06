using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleSheets.Blazor.Data
{
    public class GoogleSheetsService
    {
        public const string _appName = "GoogleSheets.Blazor";
        private readonly string _docId;
        private readonly SheetsService _service;

        public GoogleSheetsService()
        {
            var apiKey = AppSettings.SheetsApiKey;
            _docId = AppSettings.SheetsDocId;

            _service = new SheetsService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = _appName
            });
        }

        public async Task<IList<IList<object>>> Query(string spreadsheetQuery)
        {
            SpreadsheetsResource.ValuesResource.GetRequest request = _service.Spreadsheets.Values.Get(_docId, spreadsheetQuery);
            var values = await request.ExecuteAsync();

            return values.Values;
        }
    }
}
