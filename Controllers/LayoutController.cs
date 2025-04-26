using System;
using System.Web.Http;
using System.Web.Script.Serialization;
using BRD_API_REGRAS.Services;

namespace BRD_API_REGRAS.Controllers
{
    public class LayoutController : ApiController
    {
        readonly DefineLayoutService defineLayout = new DefineLayoutService();

        /// <summary>
        /// EndPoint para gerar json de estrutura de arquivos de remessa
        /// </summary>
        /// <param name="codigoLayout"></param>
        /// <returns></returns>

        // GET: Layout
        [System.Web.Http.HttpGet]
        public IHttpActionResult RetornaLayOut(string codigoLayout)
        {
            try
            {
                var layout = defineLayout.MontarJson(codigoLayout.ToUpper());

                if (layout == null)
                    return NotFound(); // Retorna HTTP 404 Not Found se o layout não for encontrado

                var jsonObject = new JavaScriptSerializer().Deserialize<object>(layout);

                return Ok(jsonObject);
            }
            catch(Exception ex)
            {
                return BadRequest("Erro na API de regras : " + ex.InnerException);

            }
        }
    }
}