using System.IO;
using Aspose.Pdf.Cloud.Sdk.Api;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Aspose.Pdf.Cloud.Sdk.Client;

namespace PDFCloudCCExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private const string BaseProductUri = @"https://api-qa.aspose.cloud";
        protected const string TestDataFolder = @"TestData";

        [HttpGet]
        public FileStreamResult Get()
        {
            AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue authorizationHeader);
            if (authorizationHeader == null)
            {
                throw new ApiException(401, "Unauthorized");
            }

            PdfApi api = new PdfApi(new Configuration(null, null, BaseProductUri));
            api.ApiClient.AccessToken = authorizationHeader.Parameter;
            //PdfApi api = new PdfApi(authorizationHeader.Parameter);

            string name = "test.pdf";
            using (Stream stream = System.IO.File.OpenRead(Path.Combine(TestDataFolder, name)))
            {
                string resFileName = "result.doc";

                var response = api.PutPdfInRequestToDoc(resFileName, file: stream);
                Stream sr = api.DownloadFile(resFileName);
                api.DeleteFile(resFileName);
                return new FileStreamResult(sr, "application/msword");
            }
        }
    }
}
