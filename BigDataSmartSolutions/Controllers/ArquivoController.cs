using System.Web.Http;
using System.Web;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Web.Http.Cors;
using System.Collections.Generic;
using BigDataSmartSolutions.Models;

namespace BigDataSmartSolutions.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ArquivoController : ApiController
    {
        [HttpPost] 
        public IHttpActionResult Converter()
        {
            /*var path = @"C:\Users\frutu\Downloads\2DevTecnologia.png";
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Arquivo.png" };
            */
            var serverPath = @"C:\Users\frutu\Downloads\2DevTecnologia.png";
            var fileInfo = new FileInfo(serverPath);

            return !fileInfo.Exists ? (IHttpActionResult)NotFound() : new FileResult(fileInfo.FullName, "application/octet-stream");
            
        }
    }
}
