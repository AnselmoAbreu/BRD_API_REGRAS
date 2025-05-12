using System;
using System.Dynamic;
using System.Web.Script.Serialization;

namespace BRD_API_REGRAS.Services
{
    public class DefineLayoutService
    {
        readonly LayoutCob400Service cobranca400 = new LayoutCob400Service();
        readonly LayoutCob240Service cobranca240 = new LayoutCob240Service();
        readonly LayoutMtp240Service mtp240 = new LayoutMtp240Service();

        public string MontarJson(string codigoArquivo)
        {
            dynamic dynamicList = new ExpandoObject();
            switch (codigoArquivo)
            {
                case "COB240":
                    cobranca240.MontarJsonCob240(dynamicList, codigoArquivo);
                    break;
                case "COB400":
                    cobranca400.MontarJsonCob400(dynamicList, codigoArquivo);
                    break;
                case "MTP240":
                    mtp240.MontarJsonMtp240(dynamicList, codigoArquivo);
                    break;
                default:
                    throw new ArgumentException("Código de arquivo inválido.");
            }

            // Serializando para JSON
            var serializer = new JavaScriptSerializer();
            string jsonResult = serializer.Serialize(dynamicList);

            // Retornando o JSON como resposta
            return jsonResult;
        }
    }
}