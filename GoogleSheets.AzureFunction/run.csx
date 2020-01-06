using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

public const string _appName = "GoogleSheets.AzureFunction";

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    var apiKey = Environment.GetEnvironmentVariable("SHEETS_API_KEY");
    var docId = Environment.GetEnvironmentVariable("SHEETS_DOC_ID");

    var service = new SheetsService(new BaseClientService.Initializer
    {
        ApiKey = apiKey,
        ApplicationName = _appName
    });

    SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(docId, "A:B");

    ValueRange spreadsheet = await request.ExecuteAsync();
    
    return new OkObjectResult(spreadsheet.Values);
}
