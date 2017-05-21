using System.Web.Http;
using System.Web;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Net.Http.Headers;

namespace BigDataSmartSolutions.Controllers
{
    public class ArquivoController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Converter()
        {
            var path = @"C:\Users\frutu\Downloads\2DevTecnologia.png";
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Arquivo.png" };
            return result;
        }
    }
}
