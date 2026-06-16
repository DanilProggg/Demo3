using TransferSimulatorApi;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:4444");

var app = builder.Build();

app.MapGet("/TransferSimulator/inn", () =>
    Results.Json(new DataResponse(DataGenerator.GenerateInn())));

app.MapGet("/TransferSimulator/fullname", () =>
    Results.Json(new DataResponse(DataGenerator.GenerateFullName())));

app.MapGet("/TransferSimulator/email", () =>
    Results.Json(new DataResponse(DataGenerator.GenerateEmail())));

app.MapGet("/TransferSimulator/phone", () =>
    Results.Json(new DataResponse(DataGenerator.GenerateMobilePhone())));

app.MapGet("/TransferSimulator/snils", () =>
    Results.Json(new DataResponse(DataGenerator.GenerateSnils())));

app.MapGet("/TransferSimulator/identitycard", () =>
    Results.Json(new DataResponse(DataGenerator.GenerateIdentityCard())));

app.Run();
