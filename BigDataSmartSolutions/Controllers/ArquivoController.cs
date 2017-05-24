using System.Web.Http;
using System.IO;
using System.Web.Http.Cors;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Linq;
using BigDataSmartSolutions.Models;

namespace BigDataSmartSolutions.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ArquivoController : ApiController
    {
        [HttpPost]
        public string Converter()
        {
            if (!HttpContext.Current.Request.Files.AllKeys.Any())
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var httpPostedFile = HttpContext.Current.Request.Files["file"];
            if (httpPostedFile != null)
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Files")))
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Files"));
                var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Files"), httpPostedFile.FileName);
                httpPostedFile.SaveAs(fileSavePath);
                var arquivoConvertido = ConversorDeArquivos.ConverterArquivo(fileSavePath);
                File.Delete(fileSavePath);
                return arquivoConvertido;
            }
            else
                throw new HttpResponseException(HttpStatusCode.BadRequest);
        }
    }
}
