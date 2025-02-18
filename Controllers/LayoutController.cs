using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BRD_API_REGRAS.Controllers
{
    public class LayoutController : ApiController
    {
        // GET: Layout
        [System.Web.Http.HttpGet]
        public IHttpActionResult RetornaLayOut(string codigoLayout)
        {
            // Aqui você pode implementar a lógica para retornar o layout conforme o código recebido
            // Exemplo simples de retorno:
            var layout = ObterLayoutPorCodigo(codigoLayout);
            if (layout == null)
            {
                return NotFound(); // Retorna HTTP 404 Not Found se o layout não for encontrado
            }
            return Ok(layout); // Retorna HTTP 200 OK com o layout encontrado
        }

        private string ObterLayoutPorCodigo(string codigo)
        {
            // Aqui você implementa a lógica para buscar o layout no seu sistema
            // Este é um exemplo simples, substitua com a sua lógica real
            if (codigo == "1")
            {
                return "Layout A";
            }
            else if (codigo == "2")
            {
                return "Layout B";
            }
            return null; // Retorno padrão caso o código não corresponda a nenhum layout
        }
    }
}