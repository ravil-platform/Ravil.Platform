using System.Net.Http.Headers;
using Logging.Base;

namespace Application.BackgroundServices
{
    public class ExportExcelToApiBackgroundService(
        IUnitOfWork unitOfWork,
        IHttpClientFactory httpClientFactory,
        ILogger<ExportExcelToApiBackgroundService> logger)
    {
        #region ( DI )
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
        protected IHttpClientFactory HttpClientFactory { get; } = httpClientFactory;
        protected ILogger<ExportExcelToApiBackgroundService> Logger { get; } = logger;
        #endregion

        public async Task CreateInteractionFile()
        {
            var excelActionHistoriesBytes = await UnitOfWork.ActionHistoriesRepository.ExportDataToExcel();
            var excelUserFileBytes = await UnitOfWork.ApplicationUserRepository.ExportDataToExcel();
            var excelJobFileBytes = await UnitOfWork.JobRepository.ExportDataToExcel();

            if (excelActionHistoriesBytes.Length == 0)
            {
                Logger.LogWarning("No data generated for the Excel file.");
                return;
            }
            
            if (excelUserFileBytes.Length == 0)
            {
                Logger.LogWarning("No data generated for the Excel file.");
                return;
            } 
            
            if (excelJobFileBytes.Length == 0)
            {
                Logger.LogWarning("No data generated for the Excel file.");
                return;
            }

            await SendFileToPythonApi(excelActionHistoriesBytes, "test_interactions.xls");
            await SendFileToPythonApi(excelUserFileBytes, "test_users.xlsx");
            await SendFileToPythonApi(excelJobFileBytes, "test_jobs_data.xlsx");
        }


        public async Task SendFileToPythonApi(byte[] fileData, string nameFile)
        {
            var client = HttpClientFactory.CreateClient();
            var requestContent = new MultipartFormDataContent();

            var fileContent = new ByteArrayContent(fileData);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            requestContent.Add(fileContent, "file", nameFile);

            var response = await client.PostAsync(RequestUri.UpdateFile, requestContent);

            if (response.IsSuccessStatusCode)
            {
                Logger.LogInformation("File successfully sent to the Python API.");
            }
            else
            {
                Logger.LogError(null, $"Failed to send the file to the Python API. Status code: {response.StatusCode}");
            }
        }
    }

}
